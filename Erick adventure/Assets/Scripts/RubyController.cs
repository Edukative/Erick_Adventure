﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rubyRB2D; // the player's Rigidboody

    // Start is called before the first frame update
    void Start()
    {
       
      rubyRB2D = GetComponent<Rigidbody2D>(); // Get the player's
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical"); // get the horizontal input

        float horizontal = Input.GetAxis("Horizontal"); // get the verticla input

        Vector2 position = transform.position; // makes a vector based on current position

        position.x = position.x + speed * horizontal * Time.deltaTime; 
         // the position is equal to the same position but a little bit bigger

        position.y = position.y + speed * vertical * Time.deltaTime; // called each second instead of each frame


        //transform.position = position; // saves this position to the current one
        rubyRB2D.MovePosition(position);

        Debug.Log("horizontal" + horizontal); // See the values are you sending when pressing the keys

    }


}
