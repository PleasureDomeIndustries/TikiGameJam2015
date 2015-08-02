using UnityEngine;
using System;
using System.Collections;

public class Thrower : MonoBehaviour {

	public float force;
	public float safeDistance;
	public bool autoFire;
	public float rateOfFire;

	Vector2 throwDir = Vector2.down;
	public GameObject heldItem;
	bool allowNextThrow;
	bool buttonWasReleased;
	
	// Use this for initialization
	void Start () {
		allowNextThrow = true;
		buttonWasReleased = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (allowNextThrow) {
			if (autoFire) {
				if (Input.GetAxis ("Fire1") > 0.5f) {
					allowNextThrow = false;
					Vector3	mouse = Input.mousePosition;
					Camera c = Camera.current;
					if (c != null) {
						Vector3 target = c.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, -c.transform.position.z));
						throwDir = (Vector2)(target - transform.position);
					}
					
					Throw(heldItem, throwDir);
					Invoke("enoughTimeHasPassed", 1.0f / rateOfFire);
				}
			} else {
				if (buttonWasReleased) {
					if (Input.GetAxis ("Fire1") > 0.5f) {
						allowNextThrow = false;
						buttonWasReleased = false;
						Vector3	mouse = Input.mousePosition;
						Camera c = Camera.current;
						if (c != null) {
							Vector3 target = c.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, -c.transform.position.z));
							throwDir = (Vector2)(target - transform.position);
						}
						
						Throw(heldItem, throwDir);
						Invoke("enoughTimeHasPassed", 1.0f / rateOfFire);
					}
				} else {
					if (Input.GetAxis ("Fire1") < 0.5f) {
						buttonWasReleased = true;
					}
				}
			}
		}
	}

	void enoughTimeHasPassed() {
		allowNextThrow = true;
	}

	public void Throw(GameObject original, Vector2 direction) {
		GameObject thrown = (GameObject)Instantiate (original, transform.position + (Vector3)direction.normalized * safeDistance, transform.rotation);
		DoesDamage dmg = thrown.GetComponent<DoesDamage> ();
		if (dmg != null)
			dmg.Owner = gameObject;
		thrown.GetComponent<Rigidbody2D> ().AddForce (direction.normalized * force);
		Destroy (thrown, 2.0f);
	}
}
