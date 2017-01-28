using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject target;
	public GameObject pickup;


	private int hitCount = 0;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		// Pressing 'F' triggers attack when key is raised
		if (Input.GetKeyUp(KeyCode.F)) {
			Attack ();
		}
	}

	private void Attack() {


		float distance = Vector3.Distance(target.transform.position, transform.position);	// Distance between player and enemy

		Debug.Log(distance);

		if (distance < 2.5) {
			hitCount++;
			if (hitCount == 1) {
				target.GetComponent<Renderer> ().material.color = Color.red;	// Change enemy color to red if hit once
			} else if (hitCount > 1) {		// On subsequent hit, destroy the enemy
				target.SetActive(false);
				Instantiate (pickup, new Vector3(target.transform.position.x, target.transform.position.y + 0.2f, target.transform.position.z), Quaternion.identity, GameObject.Find("Enemies").transform);	// Create the drop (logic for its attributes artificially set in PlayerController script)
			}
		}
	}
}
