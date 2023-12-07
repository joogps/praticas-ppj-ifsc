using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour {
	public string levelName;

    public void StartGame() {
        PlayerPrefs.SetInt("Pontos", 0);
        Application.LoadLevel(levelName);
	}
}
