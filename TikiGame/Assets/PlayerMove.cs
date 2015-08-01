﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

	public float p1_speed = 0.1f;
	public KeyCode p1_up = KeyCode.W;
	public KeyCode p1_down = KeyCode.S;
	public KeyCode p1_left = KeyCode.A;
	public KeyCode p1_right = KeyCode.D;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		Vector2 pos = (Vector2)this.transform.position;

		if (Input.GetKey (p1_up)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.up, p1_speed));
		}
		if (Input.GetKey (p1_down)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.down, p1_speed));
		}
		if (Input.GetKey (p1_left)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.left, p1_speed));
		}
		if (Input.GetKey (p1_right)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.right, p1_speed));
		}
	}
}
