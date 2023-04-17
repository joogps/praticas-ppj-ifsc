using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giro : MonoBehaviour
{
    public int velocidadeX, velocidadeY, velocidadeZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up * velocidadeX * Time.deltaTime, Space.World);
        gameObject.transform.Rotate(Vector3.right * velocidadeY * Time.deltaTime, Space.World);
        gameObject.transform.Rotate(Vector3.back * velocidadeZ * Time.deltaTime, Space.World);
    }
}
