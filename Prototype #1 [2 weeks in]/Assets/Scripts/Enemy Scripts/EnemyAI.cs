using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public bool alive = true;

	private Transform myTransform;

	void Awake() {
		myTransform = transform;	// Cache the transform (more efficient)
	}


	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");	// Find the player
		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(target.position, myTransform.position, Color.yellow);	// Draw line between enemy and player

		// Let enemy rotate to look at player
		// Interpolates between current viewing angle and target position
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		// Enemy now moves towards player
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}
}
