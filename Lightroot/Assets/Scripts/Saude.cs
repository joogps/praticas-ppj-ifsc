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
    public GameObject tooBad;

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
        saude -= x;

        if (gameObject.tag == "Player")
        {
            updateText();
        }

        if (saude <= 0)
        {
            if (gameObject.tag == "Player")
            {
                morre();
            } else {
                Destroy(gameObject);
            }
        } else if (!invencivel) {
            animator.SetTrigger("Dano");

            if (gameObject.tag == "Player") {
                invencivel = true;
                StartCoroutine(desinvencivel(4));
            }
        }
    }

    public void danoMax()
    {
        saude = 0;
        if (gameObject.tag == "Player")
        {  // Só reicicia a fase se quem morreu foi o jogador.
            morre();
        }
    }

    public void heal() {
        if (saude < 3) {
            saude++;
            updateText();
        }
    }

    public void morre() {
        morto = true;
        animator.SetTrigger("Morte");
        tooBad.SetActive(true);
        gameObject.GetComponent<Controle>().enabled = false;
        StartCoroutine(reload());
    }

    public void updateText() {
        string hearts = "";
        for (int i = 0; i < saude; i++) {
            hearts += "♥";
        }
        text.text = hearts;
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator desinvencivel(int secs)
    {
        yield return new WaitForSeconds(secs);
        invencivel = false;
    }
}