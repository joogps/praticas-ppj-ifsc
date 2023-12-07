using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {
    public Text pontosDisplay;
	public string levelName;

    void Start() {
        int pontos = PlayerPrefs.GetInt("Pontos", 0);
        pontosDisplay.text = pontos.ToString() + " PONTOS";
        
        if (pontos < PlayerPrefs.GetInt("Recorde") || !PlayerPrefs.HasKey("Recorde")) {
            PlayerPrefs.SetInt("Recorde", pontos);
        }

        PlayerPrefs.SetInt("Pontos", 0);
    }

    public void RestartGame() {
        Application.LoadLevel(levelName);
	}
}
