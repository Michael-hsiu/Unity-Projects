using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg;	// Background image of joystick (clickable region)
	private Image joystickImg;	// Actual joystick

	public Vector3 InputDirection { set; get; }

	private void Start() {
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild(0).GetComponent<Image> ();
		InputDirection = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped) {
		//Debug.Log ("OnDrag");
		Vector2 pos = Vector2.zero;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle
			(bgImg.rectTransform,	// Where you can press
				ped.position,	// Where you pressed
				ped.pressEventCamera,	// Camera active when you pressed
				out pos)) 
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;	// Whether pivot pt on right or left
			float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			InputDirection = new Vector3 (x, 0, y);		// Transform 2D -> 3D vector (no vertical movement)

			InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;	// Normalize vector

			joystickImg.rectTransform.anchoredPosition = new Vector3 (InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3), 
				InputDirection.z * (bgImg.rectTransform.sizeDelta.y / 3));

			// Debug.Log (InputDirection);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped) {
		// Debug.Log ("OnPointerDown");
		OnDrag(ped); 
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		// Debug.Log ("OnPointerUp"); 

		// Reset joystick position to middle
		InputDirection = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}
}
