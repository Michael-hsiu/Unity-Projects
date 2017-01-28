using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActivation : MonoBehaviour {

	private GameObject enemy;
	private GameObject enemyActivationButton;
	private bool enemyActive = true;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindWithTag ("Enemy");
		enemyActivationButton = GameObject.Find ("Activate Enemy Button");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Activates or deactivates enemy script
	public void ActivateEnemy() {
		if (!enemyActive) {
			enemy.GetComponent<EnemyAI> ().enabled = true;	
			enemyActivationButton.GetComponentInChildren<Text>().text = "Activate Enemy";
			enemyActive = true;
		} else {
			enemy.GetComponent<EnemyAI> ().enabled = false;
			enemyActivationButton.GetComponentInChildren<Text>().text = "Deactivate Enemy";
			enemyActive = false;
		}
	}
}
