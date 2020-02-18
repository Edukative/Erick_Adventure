using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of the enemy
    Rigidbody2D rb2D;
    public bool isVertical; // if it's not,it will walk horizontally

    //timer values
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    // animator values
    Animator animator;

    // waypoint values
    public GameObject waypoints;
    public Vector2[] localNodes;
    //private Vector2[] worldNodes;
    int currentNode;
    int nextNode;
    Vector2 velocity;

    // Start is called befor the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // get the enemy's RigidBody
        timer = changeTime; // set the timer
        animator = GetComponent<Animator>(); // get the same animator
        // waypoint stuffs
        localNodes = new Vector2[waypoints.transform.childCount];

        for (int i = 0; i <= waypoints.transform.childCount - 1; ++i)
        {
            // from 0, to the lenght of the list, while is not there, sum 1 to the counter
            Transform child = waypoints.transform.GetChild(i).transform;
            // get the transform of the child in the loop
            localNodes[i] = new Vector2(child.transform.position.x, child.transform.position.y);
            // put in the index a new Vector that is the position of the child.
            Debug.Log("index" + i + "Transform" + localNodes[i]);
        }

        currentNode = 0;
        nextNode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*timer -= Time.deltaTime; // make the timer go to 0 accordind to the time.
        
        if (timer < 0) // reaches 0
        {
            direction = -direction; // turns the direction into negative
            timer = changeTime; // resets the timer
        }*/
        // Vector2 position = rb2D.position; // get the current position of the enemy
        Vector2 wayPointDirection = localNodes[nextNode] - rb2D.position;
        UpdateAnimations(wayPointDirection.normalized);
        float dist = speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(wayPointDirection.sqrMagnitude);
        }
        if (wayPointDirection.sqrMagnitude < dist * dist) // if the enemy arrived to the waypoint
        {
            dist = wayPointDirection.magnitude;
            currentNode = nextNode; // it arrived to the waypoint so it turns to the new one
            nextNode += 1;
            if (nextNode >= localNodes.Length) // it reached the end
            {
                nextNode = 0; // it loops again and goes to the first waypoint
            }
        }

        /*if (isVertical) // if the enemy walks vertically
        {
            // same as isVertical == true;
            position.y = position.y + Time.deltaTime * speed * direction;
            // animator change values
            animator.SetFloat("Move X", 0); // keep untouched since it isn't this axis
            animator.SetFloat("Move Y", direction);
        }
        else // else condition,it wil go horizontally
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0); // keep untouched since it isn't this axis

        }*/
        // sum the position x with the speed and the time
        velocity = wayPointDirection.normalized * dist;

        rb2D.MovePosition(rb2D.position + velocity); // apply the previous sum position to the enemy's rigidbody

    }

    void UpdateAnimations (Vector2 direction)
    {
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>(); // get the script from the player

        if (player != null) // if is not empty the variable
        {
            player.ChangeHealth(-1); // damages the player
        }


    }

}
