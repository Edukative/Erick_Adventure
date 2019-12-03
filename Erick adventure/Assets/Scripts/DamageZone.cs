using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) // changed from Enter to Stay
    {
        Debug.Log("object that entered the trigger:" + other);

        RubyController controller = other.GetComponent<RubyController>(); // get the player controller from the other thing collied with the trigger

        if (controller != null)// if the controller retrieved is not empty
        {
            // 1 the exclamation is a negation value 
            controller.ChangeHealth(-1); // makes the`player to lose 1 of health
            // destroy Line out!
        }






    }
      
}
