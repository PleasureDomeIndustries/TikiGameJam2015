using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoesDamage : MonoBehaviour {

	public int DamageDone;
	public float KnockBack;
	public List<GameObject> Immune = new List<GameObject>();
	public GameObject Owner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D co){
		if (co.gameObject != Owner) {
			LivesAndDies thingToDamage = co.gameObject.GetComponent<LivesAndDies> ();
			if (thingToDamage != null) {

				//Enemies should not damage enemies
				if (thingToDamage.IsEnemy) {
					LivesAndDies mine = gameObject.GetComponent<LivesAndDies>();
					if (mine != null && mine.IsEnemy) return;
				}

				Vector2 knockBack = (co.transform.position - transform.position).normalized * KnockBack;
				thingToDamage.TakeDamage(DamageDone, knockBack);
			}
		}
	}

}
