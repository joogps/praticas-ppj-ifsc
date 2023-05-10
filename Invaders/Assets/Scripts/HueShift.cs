using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShift : MonoBehaviour
{
    public float amplitude = 1;
    public float offset = 0;

    private float h, s, v;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            Color.RGBToHSV(r.material.color, out h, out s, out v);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB((h + (Mathf.Cos(Time.timeSinceLevelLoad+offset)+1)*amplitude/2)%1, s, v);
        }
    }
}