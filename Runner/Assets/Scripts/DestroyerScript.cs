using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        
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
