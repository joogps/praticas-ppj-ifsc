using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxFactor = 0f;

    private Transform cameraTransform;

    private float Xant;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        Xant = cameraTransform.position.x;
    }

    void Update()
    {
        float deltaX = cameraTransform.position.x - Xant;

        if (deltaX > 0)
        {
            Vector3 newPos = transform.position;
            newPos.x += deltaX * parallaxFactor;
            transform.position = newPos;
        }

        Xant = cameraTransform.position.x;
    }
}
