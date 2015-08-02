using UnityEngine;
using System.Collections;

public class LivesAndDies : MonoBehaviour {

	public int Health;
	public bool DisplayHealthBar;
	public GameObject DeathEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int damage, Vector2 knockBack) {
		Debug.Log ("taking " + damage + " damage, knockback = " + knockBack.ToString ());
		Health -= damage;
		CheckHealth ();
		transform.position += (Vector3)knockBack;
	}

	void CheckHealth() {
		if (Health < 0) Die();
	}

	void Die() {
		if (DeathEffect != null)
			Instantiate(DeathEffect, gameObject.transform.position, Quaternion.identity);
		GetComponent<Animator>().SetBool("Dying",true);
		Destroy (gameObject);
	}
}
