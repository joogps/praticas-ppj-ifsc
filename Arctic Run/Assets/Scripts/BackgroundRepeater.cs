using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public float offset;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if ((transform.position.x + offset) < cameraTransform.position.x)
        {
            Vector3 newPos = transform.position;
            newPos.x += offset * 2;
            transform.position = newPos;
        }
    }
}
