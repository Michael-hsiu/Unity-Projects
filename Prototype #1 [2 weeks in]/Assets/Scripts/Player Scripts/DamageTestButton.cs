using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageTestButton : MonoBehaviour {

	private GameObject playerHealthManager;
	private GameObject damageTestButton;
	private bool takingDamage = false;

	// Use this for initialization
	void Start () {
		playerHealthManager = GameObject.Find ("PlayerHealthManager");
		damageTestButton = GameObject.Find ("Damage Test Button");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage() {
		if (!takingDamage) {
			playerHealthManager.GetComponent<PlayerHealthManager> ().enabled = true;	
			damageTestButton.GetComponentInChildren<Text>().text = "Take Damage";
			takingDamage = true;
		} else {
			playerHealthManager.GetComponent<PlayerHealthManager> ().enabled = false;
			damageTestButton.GetComponentInChildren<Text>().text = "Stop Taking Damage";
			takingDamage = false;
		}
	}
}
