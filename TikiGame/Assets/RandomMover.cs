using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour
{

    public float minDist;
    public float maxDist;
    Vector2 currentTarget;
    public float distancePerUnit = 0.1f;
    Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        currentTarget = GetNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance((Vector2) body.position,currentTarget) < 0.1f)
        {
            Collider2D collider = null;
            string collidername = "";

            do
            {
                currentTarget = GetNewTarget();
                RaycastHit2D dashit = Physics2D.Raycast(currentTarget, body.position);
                collider = dashit.collider;
                collidername = "";
                if (collider != null)
                {
                    collidername = collider.name;
                }

            } while (collidername != "Skeleton");
            
        }

        


    }

    void FixedUpdate()
    {
        Vector2 moveto = Vector2.MoveTowards(body.position, currentTarget, distancePerUnit);
        Debug.Log("Current Position: " + body.position.ToString());
        Debug.Log("Moving To: " + moveto.ToString());
        Debug.Log("Destination: " + currentTarget.ToString());


        body.MovePosition(moveto);
    }


    Vector2 GetNewTarget()
    {
        Debug.Log("Getting New Target");
        Vector2 currentPos = body.position;
        int direction = (int)System.Math.Floor((double)Random.Range(1, 4));
        float distance = Random.Range(minDist, maxDist);
        float x = 0f;
        float y = 0f;

        switch (direction)
        {
            case 1:
                x = distance;
                break;

            case 2:
                x = -distance;
                break;
            case 3:
                y = distance;
                break;
            case 4:
                y = -distance;
                break;
        }

        Vector2 newPos = currentPos + new Vector2(x, y);

        return newPos;
    }
}
