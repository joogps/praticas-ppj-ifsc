using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    Tacada t;
    LineRenderer lr;
    Rigidbody rb;

    void Start()
    {
        t = GetComponent<Tacada>();
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if (transform.position.y < -5)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            lr.enabled = true;

            Vector3 position = t.previousPosition;
            position.y += 0.5f;
            transform.position = position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.gm.CompleteLevel();
        }
    }
}
    

