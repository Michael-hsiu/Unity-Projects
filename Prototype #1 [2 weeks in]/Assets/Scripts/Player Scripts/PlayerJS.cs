using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJS : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public float drag = .5f;
	public float terminalRotationSpeed = 25.0f;

	public VirtualJoystick moveJoystick;

	private Rigidbody controller;
	private Transform camTransform;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Rigidbody> ();
		controller.maxAngularVelocity = terminalRotationSpeed;
		controller.drag = drag;
		camTransform = Camera.main.transform;
	}

	// Update is called once per frame
	void Update () {
		// Keyboard testing
		Vector3 dir = Vector3.zero;

		dir.x = Input.GetAxis ("Horizontal");
		dir.z = Input.GetAxis ("Vertical");

		if (dir.magnitude > 1) {
			dir.Normalize ();
		}

		if (moveJoystick.InputDirection != Vector3.zero) {
			dir = moveJoystick.InputDirection;
		}

		// Rotate our direction vector with camera
		Vector3 rotatedDir = camTransform.TransformDirection(dir);
		rotatedDir = new Vector3 (rotatedDir.x, 0, rotatedDir.z);
		rotatedDir = rotatedDir.normalized * dir.magnitude;

		controller.AddForce (rotatedDir * moveSpeed);
	}
}
