using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        float horizontal = Input.GetAxis("Horizontal");

        Vector2 position = transform.position;

        position.x = position.x + speed * horizontal * Time.deltaTime;

        position.y = position.y + speed * vertical * Time.deltaTime;

        transform.position = position;

    }

}
