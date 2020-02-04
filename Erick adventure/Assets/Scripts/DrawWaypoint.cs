using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWaypoint : MonoBehaviour
{
    public Transform target; // the next waypoint that the enemy goes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        // Draws a white line from this transform to the target
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
