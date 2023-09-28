using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] plataformas;
    public float spawnMin;
    public float spawnMax;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(plataformas[Random.Range(0, plataformas.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
