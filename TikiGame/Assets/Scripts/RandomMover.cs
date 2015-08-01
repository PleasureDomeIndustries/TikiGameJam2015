using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour
{

    float minDist = 1f;
    float maxDist = 4f;
    Vector2 rayCorrection;
    Vector2 currentTarget;
    Vector2 currentRaycastTarget;
    float distancePerUnit = 0.1f;
    Rigidbody2D body;
    System.Random rand;

    // Use this for initialization
    void Start()
    {
        rayCorrection = GetComponent<BoxCollider2D>().size / 2;
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
        RaycastHit2D h = Physics2D.Linecast(currentRaycastTarget, body.position);

        Collider2D collider = h.collider;
        string collidername = "";
        if (collider != null)
        {
            collidername = collider.name;
        }

        if (collidername == this.name)
        {
            float dirX = 0f;
            float dirY = 0f;
            Vector2 move =  moveto - body.position;
            if (move.x > 0.05f)
            {
                dirX = 1;
                dirY = 0;
            } else if (move.x < -0.05f)
                {
                dirX = -1;
                dirY = 0;
            } else if (move.y > 0.05f)
            {
                dirX = 0;
                dirY = 1;
            } else if (move.y < -0.05f)
            {
                dirX = 0;
                dirY = -1;
            }
            GetComponent<Animator>().SetFloat("DirX", dirX);
            GetComponent<Animator>().SetFloat("DirY", dirY);
            body.MovePosition(moveto);
        }
        else
        {
            //Debug.Log("Discarding " + currentRaycastTarget + " due to collision with " + collidername);
            GetNewTarget();
        }
       
    }


    void GetNewTarget()
    {
        //Debug.Log("Getting New Target");
        Vector2 currentPos = body.position;
        int direction = rand.Next(1, 5);
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
