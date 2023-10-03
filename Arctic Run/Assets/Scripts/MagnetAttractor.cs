using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAttractor: MonoBehaviour
{
    public float attractionForce = 0.2f;

    private float strongestForce = 0.0f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            if (player.GetComponent<Placar>().ima) {
                Vector2 directionToPlayer = player.transform.position - transform.position;
                float distanceToPlayer = directionToPlayer.magnitude;
                Vector2 normalizedDirection = directionToPlayer.normalized;

                float attractionStrength = attractionForce / Mathf.Pow(distanceToPlayer, 1.4f);
                
                if (attractionStrength > strongestForce)
                {
                    strongestForce = attractionStrength;
                }
            }

            strongestForce*= 1.05f;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, strongestForce * Time.deltaTime);
        }
    }
}