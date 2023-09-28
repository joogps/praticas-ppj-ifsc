using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] plataformas;
    public GameObject[] objetos;
    public float spawnMin;
    public float spawnMax;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(plataformas[Random.Range(0, plataformas.Length)], transform.position, Quaternion.identity);
        if (Random.Range(0, 10) < 2)
        {
            Instantiate(objetos[Random.Range(0, objetos.Length)], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
