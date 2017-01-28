using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {


	private GameObject inventoryPanel;
	private GameObject inventoryParent;

	private bool inventoryOpen = true;

	void Start() {
		inventoryPanel = GameObject.Find ("Inventory Panel");
		hideInventory (inventoryPanel);		// inventoryOpen = false

	}

	// When button is pressed

	void showInventory(GameObject inventoryParent) {
		CanvasGroup cg = inventoryPanel.GetComponent<CanvasGroup> ();
		cg.alpha = 1;
		cg.interactable = true;
		cg.blocksRaycasts = true;
		inventoryOpen = true;
	}

	void hideInventory(GameObject inventoryParent) {
		CanvasGroup cg = inventoryPanel.GetComponent<CanvasGroup> ();
		cg.alpha = 0;
		cg.interactable = false;
		cg.blocksRaycasts = false;
		inventoryOpen = false;
	}

	public void InventoryButtonPressed() {
		if (inventoryOpen) {
			hideInventory (inventoryParent);
		} else {
			showInventory (inventoryParent);
		}
	}
}
