using UnityEngine;
using System.Collections;

public class DoesDamage : MonoBehaviour {

	public int DamageDone;
	public float KnockBack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D co){
		LivesAndDies thingToDamage = co.gameObject.GetComponent<LivesAndDies> ();
		if (thingToDamage != null) {
			Vector2 knockBack = (co.transform.position - transform.position).normalized * KnockBack;
			thingToDamage.TakeDamage(DamageDone, knockBack);
		}
	}

}
