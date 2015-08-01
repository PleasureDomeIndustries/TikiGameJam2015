using UnityEngine;
using System.Collections;

public class LivesAndDies : MonoBehaviour {

	public int Health;
	public bool DisplayHealthBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage) {
		Health -= damage;
		CheckHealth ();
	}

	void CheckHealth() {
		if (Health < 0) Die();
	}

	void Die() {
		Destroy (gameObject);
	}
}
