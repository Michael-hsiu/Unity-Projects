using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler,
IPointerEnterHandler, IPointerExitHandler {
	// Handles item stacking and drag-and-drop
	public StoreItem item;
	public int amount;
	public int slot;

	// private Transform originalParent;
	private ShopInventory inv;
	private Vector2 offset;		// Offset btwn mouse click and item icon
	private ShopTooltip tooltip;
	private string data;

	public static int lastItemID = -1;

	private GameObject shopDesc;

	private void hideShop(GameObject shopDesc) {
		CanvasGroup cg = shopDesc.GetComponent<CanvasGroup>();
		cg.alpha = 0;
		cg.alpha = 0;
		cg.interactable = false;
		cg.blocksRaycasts = false;
	}

	private void showShop(GameObject shopDesc) {
		CanvasGroup cg2 = shopDesc.GetComponent<CanvasGroup> ();
		cg2.alpha = 1;
		cg2.interactable = true;
		cg2.blocksRaycasts = true;
	}

	void Start() {
		inv = GameObject.Find ("StoreInventory").GetComponent<ShopInventory> ();

		// Find ShopDesc and hide at startup.
		shopDesc = GameObject.Find ("Shop Description");

		if (shopDesc != null) {
			if (shopDesc.activeSelf) {
				hideShop(shopDesc);
			}
		}

		tooltip = inv.GetComponent<ShopTooltip> ();
	}

	void Update() {
		Debug.Log("LAST ITEM ID: " + lastItemID);
	}


	public void OnPointerEnter (PointerEventData eventData)
	{
		// Now show the shop desc.
		if (shopDesc.GetComponent<CanvasGroup>().alpha == 0) {
			showShop(shopDesc);
		}


			
		if (item.ID != -1) {
			shopDesc.SetActive (true);
			GameObject itemName = GameObject.Find ("Item Name");
			//Debug.Log ("ITEMNAME STATUS: " + (itemName == null));

			itemName.GetComponent<Text>().text = item.Title;

			GameObject itemImage = GameObject.Find ("Item Image");
			itemImage.GetComponent<Image> ().sprite = item.Sprite;

			GameObject itemDesc = GameObject.Find ("Item Description");
			itemDesc.GetComponent<Text> ().text = item.Description;
			
		}
		//Debug.Log("END LAST ITEM ID: " + lastItemID);
		//tooltip.Activate (item);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (item != null && item.ID != -1) {
			lastItemID = item.ID;	// Record the last item that user hovered over.
			//Debug.Log("LAST ITEM ID: " + lastItemID);
		}
		//TestBuy ();
		//shopDesc.SetActive (false);
		//tooltip.Deactivate ();

	}

	/* public void TestBuy() {
		//Debug.Log("TEST BUY ID: " + lastItemID);
		ShopInventory s = GameObject.Find ("StoreInventory").GetComponent<ShopInventory> ();	// Get existing StoreInventory component

		s.AddStoreItem (lastItemID);		// "Purchase" the item
	} */




	/*public void ConstructDataString() {
		data =  "<color=#00FFFF><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n" + "Power: " + item.Power + "\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}*/



	public void OnBeginDrag (PointerEventData eventData)
	{
		/* if (item.ID != -1) {
			offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
			// originalParent = this.transform.parent;
			this.transform.SetParent (this.transform.parent.parent);
			this.transform.position = eventData.position - offset;

			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}*/
	} 



	public void OnDrag (PointerEventData eventData)
	{/*
		if (item != null) {
			this.transform.position = eventData.position - offset;
		}*/
	} 



	public void OnEndDrag (PointerEventData eventData)
	{/*
		this.transform.SetParent (inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;*/
	} 


	public void OnPointerDown (PointerEventData eventData)
	{/* 
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;*/
	} 

}
