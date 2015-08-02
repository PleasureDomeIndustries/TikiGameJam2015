using UnityEngine;
using System.Collections;

public class LivesAndDies : MonoBehaviour {

	public int MaxHealth = 50;
    int currentHealth;

	public bool DisplayHealthBar;
    public Texture2D bgImage;
    public Texture2D fgImage;

    public float healthBarLength = 8f;

    // Use this for initialization
    void Start () {
        //healthBarLength = Screen.width / 2;
        currentHealth = MaxHealth;
    }
	
	void OnGUI()
    {

        Vector2 targetPos;
        targetPos = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Box(new Rect(targetPos.x - 25, Screen.height - targetPos.y - 50, 60, 20), currentHealth + "/" + MaxHealth);

    }

    public void TakeDamage(int damage, Vector2 knockBack) {
		Debug.Log ("taking " + damage + " damage, knockback = " + knockBack.ToString ());
		currentHealth -= damage;
		CheckHealth ();
		transform.position += (Vector3)knockBack;
	}

	void CheckHealth() {
        healthBarLength = (Screen.width / 2) * (currentHealth / (float)MaxHealth);

        if (currentHealth < 0) Die();
	}

	void Die() {
		Destroy (gameObject);
	}
}
