using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float speed; //speed of the enemy
    Rigidbody2D rb2D;
    public bool isVertical; // if it's not,it will walk horizontally

    //timer values
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    // Start is called befor the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // get the enemy's RigidBody
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // make the timer go to 0 accordind to the time.
        
        if (timer < 0)
        {
            direction = -direction; // turns the direction into negative
            timer = changeTime; // resets the timer
        }
        Vector2 position = rb2D.position; // get the current position of the enemy
        if (isVertical) // if the enemy walks vertically
        {
            // same as isVertical == true;
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else // else condition,it wil go horizontally
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
         // sum the position x with the speed and the time

        rb2D.MovePosition(position); // apply the previous sum position to the enemy's rigidbody

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>(); // get the script from the player

        if (player != null) // if is not empty the variable
        {
            player.ChangeHealth(-1);
        }


    }

}
