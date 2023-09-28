using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleBehavior : MonoBehaviour
{
	public string LevelToLoad;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
		    SceneManager.LoadScene(LevelToLoad);
        }
    }
}
