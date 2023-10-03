using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour
{
    public bool stageDestroyer = true;

    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            outro.gameObject.GetComponent<Placar>().gameOver();
            return;
        }
        
        if (stageDestroyer) {
            if (outro.gameObject.transform.parent)
            {
                Destroy(outro.gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(outro.gameObject);
            }
        }
    }
}
