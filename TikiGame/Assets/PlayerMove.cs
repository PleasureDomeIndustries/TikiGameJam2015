using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.right);
	}
}
