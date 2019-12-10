using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2D;
    
    // Start is called befor the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rb2D.position; // get the current position of the enemy
        position.x = position.x + Time.deltaTime * speed; // sum the position x with the speed and the time

        rb2D.MovePosition(position); // apply the previous sum position to the enemy's rigidbody

    }
}
