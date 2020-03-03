using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D projectileRB2D;

    private void Awake() // Awake is called just before the game starts
    {
        projectileRB2D = GetComponent<Rigidbody2D>(); // get the RigidBody
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000)
        {
            Destroy(gameObject); // destroys the projectile
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        projectileRB2D.AddForce(direction * force); // Adds a force to the rigisbody

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile Collision with" + other.gameObject);

        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject); // destroys the projectile


    }
}

