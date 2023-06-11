using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public int sprintSpeed = 10;
    public int jumpStrength = 125;
    public Transform terra;
    public LayerMask chao;

    private float moveX;
    private bool flipped = true;
    private bool grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX*sprintSpeed, GetComponent<Rigidbody2D>().velocity.y);
        
        // Physics2D.IgnoreLayerCollision(this.gameObject.layer, layerMask)
    }

    void LateUpdate() {
        flip();
    }

    void move() {
        moveX = Input.GetAxis("Horizontal");
        grounded = Physics2D.Linecast(transform.position, terra.position, chao);
        if (Input.GetButtonDown("Jump") && grounded) {
            jump();
        }
    }

    void jump() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpStrength);
    }

    void flip() {
        if (moveX != 0) {
            flipped = moveX > 0;
        }
        Vector2 scale = transform.localScale;
        if ((scale.x > 0 && !flipped) || (scale.x < 0 && flipped)) {
            scale.x*= -1;
            transform.localScale = scale;
        }
    }
}
