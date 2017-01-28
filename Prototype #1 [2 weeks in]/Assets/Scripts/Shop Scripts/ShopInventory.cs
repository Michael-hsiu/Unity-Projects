using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour {

	GameObject storeInventoryPanel;
	GameObject storeSlotPanel;

	StoreItemDatabase storeDatabase;
	public ShopSlot storeInventorySlot;
	public GameObject storeInventoryItem;

	int slotAmount;
	public List<StoreItem> items = new List<StoreItem>();
	public List<ShopSlot> slots = new List<ShopSlot>();

	void Start() {
		storeDatabase = GetComponent<StoreItemDatabase> ();	// Grabs database from Inventory object
		//Debug.Log(storeDatabase == null);
		storeDatabase.PrintDatabase();

		slotAmount = 16;	// Adds 16 spots to inventory
		storeInventoryPanel = GameObject.Find ("Store Inventory Panel");
		storeSlotPanel = storeInventoryPanel.transform.FindChild ("Shop Slot Panel").gameObject;	// Finds and assigns Slot Panel from Canvas

		for (int i = 0; i < slotAmount; i++) {
			items.Add (new StoreItem ());	// Add empty items
			slots.Add (Instantiate (storeInventorySlot));	// Create and add the inventory slots
			slots[i].GetComponent<ShopSlot>().id = i;
			slots[i].transform.SetParent(storeSlotPanel.transform);		// Make the parent the SlotPanel
		}

		//storeDatabase.PrintDatabase ();
		// AddStoreItem (0);
		for (int i = 0; i < 6; i++) {
			AddStoreItem (i);
		}
		/*/AddStoreItem (1);
		AddStoreItem (0);
		AddStoreItem (2);*/
		//AddStoreItem (1);
		//AddStoreItem (0);
		//AddStoreItem (1);
		//AddStoreItem (0);
		//AddStoreItem (1);
		//AddStoreItem (0);



		// Debug.Log (items [1].Title);
	}

	public void AddStoreItem(int id) {
		//Debug.Log (storeDatabase == null); // Database is not null
		//Debug.Log(id);
		StoreItem itemToAdd = storeDatabase.FetchItemByID(id);	// Get the item from the database.
		
		//Debug.Log(itemToAdd == null);	// itemToAdd is returning null; why?


		// Works for stackable items
		// Do we have it in our inventory already? Is it stackable?
		if (itemToAdd.Stackable && CheckIfItemInStore (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == id) {
					ShopItemData data = slots[i].transform.GetChild (0).GetComponent<ShopItemData> ();
					data.amount++;	// We gained 1 of this item.
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();	// Set stack amnt

					break;
				}
			}

			// So we don't have it in our inventory. We should add it!
		} else {
			for (int i = 0; i < items.Count; i++) {

				if (items [i].ID == -1) {	// Check for next empty slot.
					items [i] = itemToAdd;
					GameObject itemObject = Instantiate(storeInventoryItem);	// Put this new item in the slot

					// Set the item instance's itemData attributes.
					itemObject.GetComponent<ShopItemData>().item = itemToAdd;
					itemObject.GetComponent<ShopItemData>().slot = i;	// 'i' is the inventory slot we're adding to

					itemObject.transform.SetParent (slots [i].transform);	// Set parent to be corresponding slot
					itemObject.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObject.name = itemToAdd.Title;	// The name of item in each slot

					ShopItemData data = itemObject.GetComponent<ShopItemData> ();
					data.amount = 1;

					itemObject.transform.position = slots [i].transform.position;
					//Debug.Log (itemObject.transform.position.x);
					//Debug.Log (itemObject.transform.position.y);


					break;	// We found and processed the item. Time to leave the loop.
				}
			}
		}
	}


	private bool CheckIfItemInStore(StoreItem item) {
		for (int i = 0; i < items.Count; i++) {
			if (items[i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}
} 