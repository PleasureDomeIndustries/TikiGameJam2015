using UnityEngine;
using System.Collections;

public class ExitBehavior : MonoBehaviour {

    bool isEnabled = false;
    SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
        Debug.Log("Exit Starting Up.");
        GameManager.instance.RegisterExit(gameObject);
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.enabled = false;
	}

    public void Enable()
    {
        Debug.Log("Exit Enabling");
        isEnabled = true;
        myRenderer.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        Debug.Log(co.name + " has collided with the exit.");
        if (isEnabled && co.name.StartsWith("Player"))
        {
            Debug.Log("Entered Exit");
            GameManager.instance.NextLevel();
        }
    }

}
