using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar: MonoBehaviour
{
    public Text mostrador;
    public Text mostradorRecorde;
    public Text mostradorItens;
    private int placar;
    private int recorde;
    private int itens;
    
    void Start()
    {
        placar = 0;
        itens = 0;
        recorde = PlayerPrefs.GetInt("recorde", 0);
        mostradorRecorde.text = $"RECORDE {recorde:00000}";
        InvokeRepeating("pontua", 0.01f, 0.01f);
    }

    public void pegarItem()
    {
        itens++;
        mostradorItens.text = itens.ToString();
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
}
