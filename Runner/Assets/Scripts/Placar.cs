using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar: MonoBehaviour
{
    public Text mostrador;
    private int placar;
    
    void Start()
    {
        placar = 0;
        InvokeRepeating("pontua", 0.01f, 0.01f);
    }

    void pontua()
    {
        placar++;

        string zeros = "";
        for (int i = 0; i < 5 - placar.ToString().Length; i++)
        {
            zeros += "0";
        }
        mostrador.text = "SCORE "+zeros+placar.ToString();
    }
}
