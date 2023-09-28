using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Placar: MonoBehaviour
{
    public Text mostrador;
    public Text mostradorRecorde;
    public Text mostradorItens;
    public Image mostradorIma;
    private int placar;
    private int recorde;
    private int itens;
    public bool ima;
    
    void Start()
    {
        placar = 0;
        itens = 0;
        recorde = PlayerPrefs.GetInt("recorde", 0);
        mostradorRecorde.text = $"RECORDE {recorde:00000}";
        mostradorIma.enabled = false;
        InvokeRepeating("pontua", 0.01f, 0.01f);
    }

    public void pegarItem()
    {
        itens++;
        mostradorItens.text = itens.ToString();
    }

    public void comecarIma()
    {
        ima = true;
        mostradorIma.enabled = true;
        Invoke("terminarIma", 10f);
    }

    public void terminarIma()
    {
        ima = false;
        mostradorIma.enabled = false;
    }

    void pontua()
    {
        placar++;

        if (placar > recorde)
        {
            recorde = placar;
            PlayerPrefs.SetInt("recorde", recorde);
            mostradorRecorde.text = $"RECORDE {recorde:00000}";
        }
        mostrador.text = $"SCORE {placar:00000}"; 
    }

    public void gameOver() {
		SceneManager.LoadScene("GameOver");
    }
}
