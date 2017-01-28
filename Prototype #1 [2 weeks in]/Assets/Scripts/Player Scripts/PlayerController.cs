using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;		// Shows up in Editor :)
	//public GameObject target;

	//public Text countText;
	//public Text winText;

	private int hitCount = 0;
	private Rigidbody rb;
	//private int count;	// Private var only accessible in editor, not in Inspector/Editor

	void Start() {
		rb = GetComponent<Rigidbody> ();
		//count = 0;
		//SetCountText ();
		//winText.text = "";	// Empty string, doesn't appear at start
	}

	// Update is called once per frame
	void Update () {}

	// Called right before physics calc. Where physics code will go.
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	// Called when gameObject first touches trigger collider.
	void OnTriggerEnter(Collider other) {
		// Deactivates gameObject and all its children
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			AddItemToInventory (Random.Range(0, 6));	// Right now we have 5 unique items in the JSON!!
			//count += 1;
			//SetCountText ();
		}
	}

	public void AddItemToInventory(int id) {
		Inventory s = GameObject.Find ("Inventory").GetComponent<Inventory> ();	// Get existing StoreInventory component
		s.AddItem(id);		// "Purchase" the item
	}



	/*void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 10) {
			winText.text = "You Win!!!";
		}
	}*/
}
