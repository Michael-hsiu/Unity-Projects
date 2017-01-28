using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTooltip : MonoBehaviour {
	private Item item;
	private string data;
	private GameObject tooltip;

	void Start() {
		tooltip = GameObject.Find ("Inventory Tooltip");
		tooltip.SetActive (false);	// Tooltip is inactive at start
	}

	void Update() {
		if (tooltip.activeSelf) {
			tooltip.transform.position = Input.mousePosition;	// Let tooltip generate next to mouse position
		}
	}

	public void Activate(Item item) {
		this.item = item;	
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	public void Deactivate() {
		tooltip.SetActive (false);
	}

	public void ConstructDataString() {
		data =  "<color=#00FFFF><b>" + item.Title + "</b></color>\n\n" + item.Description + "\n" + "Power: " + item.Power + "\n";
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}
}
