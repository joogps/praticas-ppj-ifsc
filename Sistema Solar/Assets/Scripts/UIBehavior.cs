using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBehavior : MonoBehaviour
{
    private bool hasStarted = false;
    
    static public Text tooltip;
    private RaycastHit hit;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        tooltip = GameObject.Find("Tooltip").GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!hasStarted) {
                anim.SetTrigger("Start");
                hasStarted = true;
                SetFocus();
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
            {
                SetFocus();
            }
        }
    }

    void SetFocus() {
        GameObject sun = GameObject.Find("Sol");
		LookAtTarget.target = sun;
		LookAtTarget.size = sun.transform.localScale.x*2f+5;
		tooltip.text = "SISTEMA SOLAR";
    }
}
