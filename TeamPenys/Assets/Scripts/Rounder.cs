using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounder : MonoBehaviour
{
    public GlobalTimer GlobalTimerScript;
    public Victory VictoryScript;
    [Range(1, 2)] public int PlayerNumber;

    public int Vitorias = 0;

    public void GiveMedal()
    {
        if (Vitorias <= 1)
        {
            gameObject.transform.GetChild(Vitorias).gameObject.SetActive(true);
            //GlobalTimerScript.RestartClock();
            Vitorias++;
            GlobalTimerScript._timeLeft = 99;
            if(Vitorias > 1)
            {
                Debug.Log("WINNER!! P" + PlayerNumber);
            }
        }
    }
}
