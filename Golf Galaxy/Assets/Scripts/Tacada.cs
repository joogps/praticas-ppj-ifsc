﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacada : MonoBehaviour
{
    public float maxX, maxZ;
    private float x, z;
    private Vector2 pi;
    private Vector2 pf;
    private float velocidade;

    public Vector3 previousPosition;

    LineRenderer lr;
    Rigidbody rb;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        if (lr == null)
            Debug.Log("Adicionar LineRenderer!!");
        lr.enabled = false;
    }

    void Update()
    {   
        if (transform.position.y < -10)
        {
            previousPosition.y += 0.5f;
            transform.position = previousPosition;
        }

        velocidade = rb.velocity.magnitude;
        if (velocidade < 0.5f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            lr.enabled = true;
        }
        else
        {
            lr.enabled = false;
        }

        if (lr.enabled)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    pi = t.position;
                    pf = t.position;
                    x = 0;
                    z = 0;
                    lr.enabled = true;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, transform.position);
                }

                if (t.phase == TouchPhase.Moved)
                {
                    pf = t.position;
                    x = (pi.x - pf.x) * 0.03f;
                    z = (pi.y - pf.y) * 0.03f;
                    if (x > maxX)
                        x = maxX;
                    if (z > maxZ)
                        z = maxZ;
                    lr.SetPosition(1, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z));
                }

                if (t.phase == TouchPhase.Ended)
                {
                    GameManager.gm.FazerTacada(); 
                    previousPosition = transform.position;
                    GetComponent<Rigidbody>().AddForce(new Vector3(2 * x, 0, 2 * z), ForceMode.Impulse);
                    lr.enabled = false;
                }
            }
        }
    }
}
    

