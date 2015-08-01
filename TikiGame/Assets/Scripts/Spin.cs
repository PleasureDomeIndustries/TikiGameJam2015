using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float rotation = -10;

    void Update()
    {
        var rigid = GetComponent<Rigidbody2D>();
        if (rigid.velocity.magnitude > 0)         transform.Rotate(Vector3.forward * rotation);
    }
}
