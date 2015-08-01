using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

	public float p1_speed = 0.5f;
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
		if (Input.GetKeyDown (p1_up)) {
//			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(trans
		}
	}
}
