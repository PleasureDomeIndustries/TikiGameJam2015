using UnityEngine;
using System.Collections;

public class RandomMover : MonoBehaviour
{

    public float minDist;
    public float maxDist;
    Vector2 currentTarget;
    public float distancePerUnit = 0.1f;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting Skeleton");
        currentTarget = GetNewTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2) transform.position == currentTarget) currentTarget = GetNewTarget();

        Vector2 moveto = Vector2.MoveTowards(transform.position, currentTarget, distancePerUnit);
        Debug.Log("Current Position: " & transform.position.ToString());
        Debug.Log("Moving To: " & moveto.ToString());
        GetComponent<Rigidbody2D>().MovePosition(moveto);


    }

    Vector2 GetNewTarget()
    {
        Debug.Log("Getting New Target");
        Vector2 currentPos = transform.position;
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
