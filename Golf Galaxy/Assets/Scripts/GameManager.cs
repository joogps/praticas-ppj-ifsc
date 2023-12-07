using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int par = 0;
	public string nextLevelName;

	public static GameManager gm;

	public Text scoreDisplay;
	public Text tacadasDisplay;
	public Text parDisplay;
    public Text recordeDisplay;

	public Text resultDisplay;
	public GameObject levelClear;

	int tacadas = 0;
    int pontos = 0;

	void Start () {
		gm = this.gameObject.GetComponent<GameManager>();

        pontos = PlayerPrefs.GetInt("Pontos", 0);

		scoreDisplay.text = pontos.ToString()+" PONTOS";
        tacadasDisplay.text = "0 TACADAS";
        parDisplay.text = par.ToString() + " PAR";
        recordeDisplay.text = PlayerPrefs.GetInt("Recorde", 0).ToString() + " RECORDE";
	}

    public void CalcularResultado() {
        int resultado = (tacadas/2) - par;
        switch (resultado)
        {
            case -3:
                resultDisplay.text = "ALBATROSS";
                break;
            case -2:
                resultDisplay.text = "EAGLE";
                break;
            case -1:
                resultDisplay.text = "BIRDIE";
                break;
            case 0:
                resultDisplay.text = "PAR";
                break;
            case 1:
                resultDisplay.text = "BOGEY";
                break;
            case 2:
                resultDisplay.text = "DOUBLE BOGEY";
                break;
            case 3:
                resultDisplay.text = "TRIPLE BOGEY";
                break;
            default:
                resultDisplay.text = (tacadas/2).ToString() + " TACADAS";
                break;
        }

        int pontuacao = pontos+resultado;
        scoreDisplay.text = pontuacao.ToString()+" PONTOS";
        PlayerPrefs.SetInt("Pontos", pontuacao);

        levelClear.SetActive(true);
    }

    public void FazerTacada()
    {
        tacadas++;
        tacadasDisplay.text = (tacadas/2).ToString() + " TACADAS";
    }

	public void CompleteLevel() {
        CalcularResultado();
	}

    public void NextLevel() {
        Application.LoadLevel(nextLevelName);
	}
}
