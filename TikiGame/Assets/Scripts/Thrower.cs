using UnityEngine;
using System.Collections;

public class Thrower : MonoBehaviour {

	public float force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Throw(GameObject original, Vector2 direction) {
		GameObject thrown = (GameObject)Instantiate (original, transform.position + (Vector3)direction.normalized * 3.0f, transform.rotation);
		thrown.GetComponent<Rigidbody2D> ().AddForce (direction.normalized * force);
		Destroy (thrown, 2.0f);
	}
}
