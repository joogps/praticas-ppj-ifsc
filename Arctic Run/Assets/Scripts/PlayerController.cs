using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        private bool facingRight = false;
        [HideInInspector]

        private bool isGrounded;
        private bool doubleJump;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            moveInput = 1;
            Vector3 direction = transform.right * moveInput;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetInteger("playerState", 1);
            
            if(Input.GetMouseButtonDown(0) && (isGrounded || doubleJump))
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                doubleJump = isGrounded;
                
            }

            if (!isGrounded)animator.SetInteger("playerState", 2);
        }

        private void Flip()
        {
            facingRight = !facingRight;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Placar>().gameOver();
            }
        }
    }
}
