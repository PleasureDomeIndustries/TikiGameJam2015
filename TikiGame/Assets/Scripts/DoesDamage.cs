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
		LivesAndDies damaged = co.gameObject.GetComponent<LivesAndDies> ();
		if (damaged != null) {
			Vector2 knock = (co.transform.position - transform.position).normalized * KnockBack;
			damaged.TakeDamage(DamageDone, knock);
		}
	}

}
