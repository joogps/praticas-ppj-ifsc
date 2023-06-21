using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    int hits = 3;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), 
                                  GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());

        Destroy (gameObject, 10);
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Inimigo"){
            Destroy(gameObject);
            collision.collider.gameObject.GetComponent<Saude>().dano(1);
        }

        hits--;
        if (hits < 0){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy (gameObject, 5);
        } else {
            ReflectProjectile(collision.contacts[0].normal);
        }
    }

    private void ReflectProjectile(Vector3 reflectVector)
    {    
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.Reflect(rb.velocity, reflectVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
