using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenuScript : MonoBehaviour {


	private GameObject shopPanel;
	private GameObject shopDesc;

	private bool shopOpen = true;	// Is the inventory open?
	private bool menuOpen = true;

	void Start() {
		shopPanel = GameObject.Find ("Store Inventory Panel");
		shopDesc = GameObject.Find ("Shop Description");

		hideShop(shopPanel, shopDesc);
	}


	void showShop(GameObject shopPanel, GameObject shopDesc) {
		CanvasGroup cg = shopPanel.GetComponent<CanvasGroup> ();
		cg.alpha = 1;
		cg.interactable = true;
		cg.blocksRaycasts = true;
		shopOpen = true;

		//CanvasGroup cg2 = shopDesc.GetComponent<CanvasGroup> ();
		//cg2.alpha = 1;
		//cg2.interactable = true;
		//cg2.blocksRaycasts = true;
		//menuOpen = true;
	}

	void hideShop(GameObject shop, GameObject shopDesc) {
		CanvasGroup cg = shopPanel.GetComponent<CanvasGroup> ();
		cg.alpha = 0;
		cg.interactable = false;
		cg.blocksRaycasts = false;
		shopOpen = false;

		CanvasGroup cg2 = shopDesc.GetComponent<CanvasGroup> ();
		cg2.alpha = 0;
		cg2.interactable = false;
		cg2.blocksRaycasts = false;
		menuOpen = false;
	}

	// When button is pressed
	public void ShopButtonPressed() {
		if (shopOpen) {
			hideShop (shopPanel, shopDesc);
		} else {
			showShop (shopPanel, shopDesc);
		}
	}
}
