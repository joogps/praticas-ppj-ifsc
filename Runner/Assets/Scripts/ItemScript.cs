using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            outro.gameObject.GetComponent<Placar>().pegarItem();
            Destroy(gameObject);
        } else if (outro.gameObject.tag == "Magnet")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.GetComponent<Placar>().ima) {
                player.GetComponent<Placar>().pegarItem();
                Destroy(gameObject);
            }
        }
    }
}
