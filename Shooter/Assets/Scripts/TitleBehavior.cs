using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleBehavior : MonoBehaviour
{
	public string LevelToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
		    SceneManager.LoadScene(LevelToLoad);
        }
    }
}
