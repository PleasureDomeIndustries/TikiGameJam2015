using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerMove : NetworkBehaviour {

	public float p1_speed = 0.1f;
	public KeyCode p1_up = KeyCode.W;
	public KeyCode p1_down = KeyCode.S;
	public KeyCode p1_left = KeyCode.A;
	public KeyCode p1_right = KeyCode.D;

	public GameObject heldItem;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
		Vector2 pos = (Vector2)this.transform.position;

		if (Input.GetKey (p1_up)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.up, p1_speed));
			GetComponent<Animator>().SetFloat("DirY",1f);
			GetComponent<Animator>().SetFloat("DirX",0);
		}
		if (Input.GetKey (p1_down)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.down, p1_speed));
			GetComponent<Animator>().SetFloat("DirY",-1f);
			GetComponent<Animator>().SetFloat("DirX",0);
		}
		if (Input.GetKey (p1_left)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.left, p1_speed));
			GetComponent<Animator>().SetFloat("DirX",-1f);
			GetComponent<Animator>().SetFloat("DirY",0);
		}
		if (Input.GetKey (p1_right)) {
			GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(pos, pos + Vector2.right, p1_speed));
			GetComponent<Animator>().SetFloat("DirX",1f);
			GetComponent<Animator>().SetFloat("DirY",0);
		}

		if (Input.GetAxis ("Fire3") > 0.5f) {
			GetComponent<Thrower>().Throw(heldItem);
		}
	}
}
