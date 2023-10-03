using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform jogador;

    void Update()
    {
        transform.position = new Vector3(jogador.position.x, 0, -10);
    }
}
