using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public int Damage = 100;
    [HideInInspector] public bool Result;
    [HideInInspector] public bool _check = false;

    private void Update()
    {
        if (this.GetComponent<Slider>().value <= this.GetComponent<Slider>().minValue)
        {
            Debug.Log("Morreu");
        }
    }
}
