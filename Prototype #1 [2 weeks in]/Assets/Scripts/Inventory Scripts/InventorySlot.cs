using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler {
	public int id;
	private Inventory inv;

	public void OnDrop (PointerEventData eventData)
	{
		InventoryItemData droppedItem = eventData.pointerDrag.GetComponent<InventoryItemData> ();

		Debug.Log (inv.items [id].ID);

		if (inv.items[id].ID == -1) {	// If there's no item in this slot
			inv.items[droppedItem.slot] = new Item();	// Clear out slot we dragged out of (old slot)
			inv.items[id] = droppedItem.item;	// Fill new slot
			droppedItem.slot = id;	// Updates slot of item we just dragged to new slot ID
		} else if (droppedItem.slot != id) {	

			Transform item = this.transform.GetChild(0);
			item.GetComponent<InventoryItemData>().slot = droppedItem.slot;
			item.transform.SetParent(inv.slots[droppedItem.slot].transform);
			item.transform.position = inv.slots[droppedItem.slot].transform.position;

			inv.items[droppedItem.slot] = item.GetComponent<InventoryItemData>().item;
			inv.items[id] = droppedItem.item;
			droppedItem.slot = id;
		
			/*
			// There's already an item there, so swap locations

			// Move out of old slot
			Transform item = this.transform.GetChild(0);
			item.GetComponent<ItemData> ().slot = droppedItem.slot;
			item.transform.SetParent (inv.slots [droppedItem.slot].transform);
			item.transform.position = inv.slots [droppedItem.slot].transform.position;

			// Move into new slot
			droppedItem.slot = id;
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.position;

			inv.items [droppedItem.slot] = item.GetComponent<ItemData> ().item;
			inv.items[id] = droppedItem.item; 
			*/
			
		}
	}


	void Start () {
		
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();

	}

}
