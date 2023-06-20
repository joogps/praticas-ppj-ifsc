using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Saude : MonoBehaviour
{

    public bool morto;
    public bool invencivel;
    public int saude;
    private Animator animator;
    public Text text;

    // Use this for initialization
    void Start()
    {
        morto = false;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
    }

    public void dano(int x)
    {
        if (saude <= 1)
        {
            morto = true;
            animator.SetTrigger("Morte");
            if (gameObject.tag == "Player")
            {
                StartCoroutine(morre());
            } else {
                Destroy(gameObject);
            }
        } else if (!invencivel) {
            saude -= x;
            animator.SetTrigger("Dano");

            if (gameObject.tag == "Player") {
                invencivel = true;
                StartCoroutine(desinvencivel(4));
            }
        }

        if (gameObject.tag == "Player")
        {
            updateText();
        }
    }

    public void danoMax()
    {
        saude = 0;
        morto = true;
        // animator.SetTrigger("Morte");
        if (gameObject.tag == "Player")
        {  // Só reicicia a fase se quem morreu foi o jogador.
            StartCoroutine(morre());
        }
    }

    public void updateText() {
        string hearts = "";
        for (int i = 0; i < saude; i++) {
            hearts += "♥";
        }
        text.text = hearts;
    }

    IEnumerator morre()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator desinvencivel(int secs)
    {
        yield return new WaitForSeconds(secs);
        invencivel = false;
    }
}