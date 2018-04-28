using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoMain : MonoBehaviour {

	 public float speed = .5f;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.UpArrow)) {
			body.AddForce(Vector3.forward * speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			body.AddForce(Vector3.back * speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			body.AddForce(Vector3.left * speed);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			body.AddForce(Vector3.right * speed);
		}
	}
}
