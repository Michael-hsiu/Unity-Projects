using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTooltip : MonoBehaviour {
	private StoreItem shopItem;
	private string data;
	private GameObject shopTooltip;

	void Start() {
		shopTooltip = GameObject.Find ("Shop Tooltip");
		shopTooltip.SetActive (false);	// Tooltip is inactive at start
	}

	void Update() {
		if (shopTooltip.activeSelf) {
			shopTooltip.transform.position = Input.mousePosition;	// Let tooltip generate next to mouse position
		}
	}

	public void Activate(StoreItem item) {
		this.shopItem = item;	
		ConstructDataString ();
		shopTooltip.SetActive (true);
	}

	public void Deactivate() {
		shopTooltip.SetActive (false);
	}

	public void ConstructDataString() {
		data =  "<color=#00FFFF><b>" + shopItem.Title + "</b></color>\n\n" + shopItem.Description + "\n" + "Power: " + shopItem.Power + "\n";
		shopTooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}
}
