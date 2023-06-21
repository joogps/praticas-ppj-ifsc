using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ItemBehavior : MonoBehaviour
{
    public bool heart;
    public bool bullets;
    public bool endpoint;
    public GameObject levelClear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == "Player"){
            if (heart) {
                collision.collider.gameObject.GetComponent<Saude>().heal();
                Destroy(gameObject);
            }

            if (bullets) {
                collision.collider.gameObject.GetComponent<Controle>().reload();
                Destroy(gameObject);
            }

            if (endpoint) {
                levelClear.SetActive(true);
                collision.collider.gameObject.SetActive(false);
                StartCoroutine(reload());
            }
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
