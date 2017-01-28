using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour {

	private int testInt = 1;

	public void BuyStoreItem() {
		Inventory s = GameObject.Find ("Inventory").GetComponent<Inventory> ();	// Get existing StoreInventory component
		s.AddItem(ShopItemData.lastItemID);		// "Purchase" the item
	}

	/** Inserts the purchased item into the shop inventory. For testing purposes. */
	public void TestBuy() {
		//Debug.Log("TEST BUY ID: " + lastItemID);
		ShopInventory s = GameObject.Find ("StoreInventory").GetComponent<ShopInventory> ();	// Get existing StoreInventory component
		s.AddStoreItem (ShopItemData.lastItemID);		// "Purchase" the item
	}



	public void test() {
		Debug.Log ("Buy button was pressed " + testInt + " times.");
		Debug.Log ("BUTTON SCRIPT: " + ShopItemData.lastItemID);
		testInt++;
	}
}
