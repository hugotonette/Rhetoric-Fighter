using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Rounder RounderScriptP1;
    public Rounder RounderScriptP2;
    public int Damage = 25;
    [HideInInspector] public bool Result;
    [HideInInspector] public bool _check = false;

    private void Update()
    {
        if (this.GetComponent<Slider>().value >= this.GetComponent<Slider>().maxValue)
        {
            this.GetComponent<Slider>().value = 0;
            Debug.Log("P2 Morreu");
            RounderScriptP1.GiveMedal();
        }
        else if(this.GetComponent<Slider>().value <= this.GetComponent<Slider>().minValue)
        {
            this.GetComponent<Slider>().value = 0;
            Debug.Log("P1 Morreu");
            RounderScriptP2.GiveMedal();
        }
    }
}
