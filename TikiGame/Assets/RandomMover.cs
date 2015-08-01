﻿using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour
{

    public float minDist;
    public float maxDist;
    Vector2 rayCorrection;
    Vector2 currentTarget;
    Vector2 currentRaycastTarget;
    public float distancePerUnit = 0.1f;
    Rigidbody2D body;
    System.Random rand;

    // Use this for initialization
    void Start()
    {
        rayCorrection = GetComponent<BoxCollider2D>().size;
        rand = new System.Random();
        body = GetComponent<Rigidbody2D>();
        GetNewTarget();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance((Vector2)body.position, currentTarget) < 0.1f)
        {
            GetNewTarget();
        }

        Vector2 moveto = Vector2.MoveTowards(body.position, currentTarget, distancePerUnit);
        RaycastHit2D h = Physics2D.Raycast(currentRaycastTarget, body.position);

        Collider2D collider = h.collider;
        string collidername = "";
        if (collider != null)
        {
            collidername = collider.name;
        }

        if (collidername == "Skeleton")
        {
            body.MovePosition(moveto);
        }
        else
        {
            GetNewTarget();
        }
       
    }


    void GetNewTarget()
    {
        Debug.Log("Getting New Target");
        Vector2 currentPos = body.position;
        int direction = rand.Next(1, 4);
        float distance = Random.Range(minDist, maxDist);
        float x = 0f;
        float y = 0f;
        float xRay = 0f;
        float yRay = 0f;

        switch (direction)
        {
            case 1:
                x = distance;
                xRay = distance + rayCorrection.x;
                break;

            case 2:
                x = -distance;
                xRay = -distance - rayCorrection.x;
                break;
            case 3:
                y = distance;
                yRay = distance + rayCorrection.y;
                break;
            case 4:
                y = -distance;
                yRay = -distance - rayCorrection.y;
                break;
        }

        currentTarget = currentPos + new Vector2(x, y);
        currentRaycastTarget = currentPos + new Vector2(xRay, yRay);
    }
}
