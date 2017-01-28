using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	
	GameObject inventoryPanel;
	GameObject slotPanel;

	ItemDatabase database;
	public InventorySlot inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<InventorySlot> slots = new List<InventorySlot>();

	void Start() {
		database = GetComponent<ItemDatabase> ();	// Grabs database from Inventory object

		slotAmount = 16;	// Adds 16 spots to inventory
		inventoryPanel = GameObject.Find ("Inventory Panel");
		slotPanel = inventoryPanel.transform.FindChild ("Slot Panel").gameObject;	// Finds and assigns Slot Panel from Canvas

		for (int i = 0; i < slotAmount; i++) {
			items.Add (new Item ());	// Add empty items
			slots.Add (Instantiate (inventorySlot));	// Create and add the inventory slots
			slots[i].GetComponent<InventorySlot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);		// Make the parent the SlotPanel
		}

		AddItem (0);
		AddItem (1);
		AddItem (0);
		AddItem (1);

		for (int i = 2; i < 6; i++) {
			AddItem (i);
		}

		for (int i = 0; i < 20; i++) {
			AddItem (4);
		}

		for (int i = 0; i < 32; i++) {
			AddItem (5);
		}
		//AddItem (1);
		//AddItem (2);

		// Debug.Log (items [1].Title);
	}

	public void AddItem(int id) {
		Item itemToAdd = database.FetchItemByID (id);	// Get the item from the database.
		//database.PrintDatabase();

		/* Works for stackable items */
		// Do we have it in our inventory already? Is it stackable?
		if (itemToAdd.Stackable && CheckIfItemInInventory (itemToAdd)) {
			for (int i = 0; i < items.Count; i++) {
				if (items [i].ID == id) {
					InventoryItemData data = slots [i].transform.GetChild (0).GetComponent<InventoryItemData> ();
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
					GameObject itemObject = Instantiate(inventoryItem);	// Put this new item in the slot

					// Set the item instance's itemData attributes.
					itemObject.GetComponent<InventoryItemData>().item = itemToAdd;
 					itemObject.GetComponent<InventoryItemData>().slot = i;	// 'i' is the inventory slot we're adding to

					itemObject.transform.SetParent (slots [i].transform);	// Set parent to be corresponding slot

					itemObject.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObject.name = itemToAdd.Title;	// The name of item in each slot

					InventoryItemData data = itemObject.GetComponent<InventoryItemData> ();
					data.amount = 1;

					itemObject.transform.position = slots [i].transform.position;


					break;	// We found and processed the item. Time to leave the loop.
				}
			}
		}
	}

	private bool CheckIfItemInInventory(Item item) {
		for (int i = 0; i < items.Count; i++) {
			if (items[i].ID == item.ID) {
				return true;
			}
		}
		return false;
	}
}
