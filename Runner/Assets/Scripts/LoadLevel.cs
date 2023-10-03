using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel: MonoBehaviour
{
	public string LevelToLoad;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
		SceneManager.LoadScene(LevelToLoad);
    }
}
