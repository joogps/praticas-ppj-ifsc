using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] plataformas;
    public GameObject[] objetos;
    public GameObject[] powerUps;
    public float spawnMin;
    public float spawnMax;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(plataformas[Random.Range(0, plataformas.Length)], transform.position, Quaternion.identity);

        int chance = Random.Range(0, 30);
        if (chance < 1)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        } else if (chance < 10) {
            Instantiate(objetos[Random.Range(0, objetos.Length)], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
