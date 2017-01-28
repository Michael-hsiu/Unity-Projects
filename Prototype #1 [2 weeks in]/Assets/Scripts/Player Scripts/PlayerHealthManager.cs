using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

	public static int health = 100;
	public GameObject player;
	public Slider healthBar; 

	//private int interval = 1;
	//private float nextTime = 0;
	//private float timer;
	//private float countTime;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("ReduceHealth", 1, 1);	// Call 1 sec after start, then 1 sec after that forever
	}
	
	// Update is called once per frame
	void Update () {

		/*if (countTime) {
			timer += Time.deltaTime;
		}*/
		// If the next update is reached
		/*if (Time.time >= nextTime) {
			// Call function
			ReduceHealth();

			nextTime += interval;
		}*/
	}

	void ReduceHealth() {
		health -= 1;
		healthBar.value = health;

		if (health <= 0) {
			// Change color of Player using materials
			Material newColor = (Material) Resources.Load ("Materials/Red");
			player.GetComponent<Renderer> ().material = newColor;
			//player.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
		}
		//Debug.Log ("Health: " + health);
	}
}
