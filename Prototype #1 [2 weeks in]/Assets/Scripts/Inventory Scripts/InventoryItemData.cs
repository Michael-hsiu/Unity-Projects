﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler,
IPointerEnterHandler, IPointerExitHandler {
	// Handles item stacking and drag-and-drop
	public Item item;
	public int amount;
	public int slot;

	// private Transform originalParent;
	private Inventory inv;
	private Vector2 offset;		// Offset btwn mouse click and item icon
	private InventoryTooltip tooltip;

	void Start() {
		inv = GameObject.Find ("Inventory").GetComponent<Inventory> ();
		tooltip = inv.GetComponent<InventoryTooltip> ();
	}

	public void OnBeginDrag (PointerEventData eventData)
	{
		if (item.ID != -1) {
			offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
			// originalParent = this.transform.parent;
			this.transform.SetParent (this.transform.parent.parent);
			this.transform.position = eventData.position - offset;

			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}



	public void OnDrag (PointerEventData eventData)
	{
		if (item != null) {
			this.transform.position = eventData.position - offset;
		}
	}
	


	public void OnEndDrag (PointerEventData eventData)
	{
		this.transform.SetParent (inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}


	public void OnPointerDown (PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
		this.transform.position = eventData.position - offset;
	}
		
	public void OnPointerEnter (PointerEventData eventData)
	{
		tooltip.Activate (item);
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		tooltip.Deactivate ();
	}

}