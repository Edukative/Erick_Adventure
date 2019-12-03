using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("object that entered the trigger: " + other);

        RubyController controller = other.GetComponent<RubyController>();
        // get the player controller from the other thing collided with the trigger

        if (controller != null) // if the controller retrieved is not empty
        {
            // ! the exclamation is a negation value
            if (controller.currentHealth < controller.maxHealth) // if the health is not at the maximum
            {
                controller.ChangeHealth(1);
                // call the health function and add 1 to the health of the player

                Destroy(gameObject); // Destroys all the game object and this script too!
            }
            
        }
    }

    


    
}
