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

	public void Throw(GameObject original) {
		GameObject thrown = (GameObject)Instantiate (original, transform.position, transform.rotation);
		thrown.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * force);
		Destroy (thrown, 1.0f);
	}
}
