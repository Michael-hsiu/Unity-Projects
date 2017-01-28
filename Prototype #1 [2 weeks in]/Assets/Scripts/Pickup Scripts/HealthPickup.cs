using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		//Debug.Log("COLLISION OCCURRED!");

		// Triggers on collision with rigidbody's collider
		if(PlayerHealthManager.health < 100 && PlayerHealthManager.health > 0) {
			int missingHealth = 100 - PlayerHealthManager.health;
			int healthToAdd = (missingHealth < 100) ? missingHealth : 100;	// Restore missing HP if <10 missing, otherwise restore 10 HP
			PlayerHealthManager.health += healthToAdd;
			Debug.Log ("PLAYER HEALTH: " + PlayerHealthManager.health);

			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
