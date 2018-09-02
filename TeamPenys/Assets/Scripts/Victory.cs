using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public Rounder P1Rounder;
    public Rounder P2Rounder;
    public GameObject GameOverScreen;

    public GameObject[] ThingsToDisable;

    private void Update()
    {
        if(P1Rounder.Vitorias >= 2 || P2Rounder.Vitorias >= 2)
        {
            GameOverScreen.SetActive(true);
            foreach (GameObject item in ThingsToDisable)
                item.SetActive(false);
        }
    }
}