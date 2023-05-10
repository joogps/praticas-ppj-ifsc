using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float amplitude = 1;
    public float offset = 0;

    public bool x = false;
    public bool y = false;
    public bool z = false;

    // Start is called before the first frame update
    void Start()
    {
        // x = Random.value > 0.6;
        // y = Random.value > 0.6;
        // z = Random.value > 0.6;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = x ? Vector3.right : (y ? Vector3.up : (z ? Vector3.back : Vector3.zero));
        float vel = amplitude * Mathf.Cos((Time.timeSinceLevelLoad+offset)*Mathf.PI);

        if (direction != Vector3.zero) {
            gameObject.transform.transform.Translate(direction * vel, Space.World);
        }
    }
}