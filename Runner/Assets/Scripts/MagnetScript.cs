using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            outro.gameObject.GetComponent<Placar>().comecarIma();
            Destroy(gameObject);
        }
    }
}
