using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fights : MonoBehaviour
{
    public GameObject RefereeTimer;
    public GlobalTimer Maintime;
    [Range(0, 5)] public float TotalTimeBetweenRounds = 3;
    public ComboPrompt ComboScriptP1;
    public PlayerInput PlayerInputScriptP1;
    public GameObject[] PromptP1;
    [Space]
    public ComboPrompt ComboScriptP2;
    public PlayerInput PlayerInputScriptP2;
    public GameObject[] PromptP2;
    public Rounder P1;
    public Rounder P2;
    private int Round = 1;
    [Range(0, 5)] public float tempoMostrando = 3;
    
    private float _timeLeft;
    private bool _canCooldown = false;

    /*
     * ContadoR: juiz falado 3,2,1...go!
     * ligar o Prompt de Inputs
     * Ligar RandomInputs (gerar novos inputs no prompt)
     * Esperar um tempo
     * Desligar o Prompt de Inputs
     * Permite o player colocar inputs
     * */

    IEnumerator TimeToWait()
    {
        _canCooldown = true;
        yield return new WaitForSeconds(TotalTimeBetweenRounds);
        StartCoroutine(WaitPrompt());
        _canCooldown = false;
    }

    IEnumerator WaitPrompt()
    {
        SetActivePrompt(true);
        ComboScriptP1.RandomInputs();
        ComboScriptP2.RandomInputs();
        yield return new WaitForSeconds(tempoMostrando);
        SetActivePrompt(false);
    }
    IEnumerator SimplesWait()
    {
        RefereeTimer.GetComponent<Text>().text = "Round" + Round;
        yield return new WaitForSeconds(10);
    }

    private void SetActivePrompt(bool state)
    {
        PlayerInputScriptP1.AbleToClick = !state;
        foreach (GameObject item in PromptP1)
            item.SetActive(state);
        PlayerInputScriptP1.enabled = !state;

        PlayerInputScriptP2.AbleToClick = !state;
        foreach (GameObject item in PromptP2)
            item.SetActive(state);
        PlayerInputScriptP2.enabled = !state;
    }

    public void NewRound()
    {
        StartCoroutine(TimeToWait());
    }

    private void Start()
    {
        _timeLeft = TotalTimeBetweenRounds;
    }

    private void Update()
    {
        if (P1.Vitorias == 1 || P2.Vitorias == 1)
            Round = 2;
        else if (P1.Vitorias == 1 && P2.Vitorias == 1)
            Round = 3;
        if (_canCooldown)
        {
            if (_timeLeft > 1)
            {
                Maintime.pausado = true;
                if(Maintime._timeLeft == 99)
                {
                    RefereeTimer.GetComponent<Text>().text = "Round\n" + Round;
                }
                _timeLeft = _timeLeft - Time.deltaTime;
                //RefereeTimer.GetComponent<Text>().text = Mathf.Round(_timeLeft).ToString();
            }
            else
            {
         
                SimplesWait();
                //RefereeTimer.GetComponent<Text>().text = "GO";
                Maintime.pausado = false;
                Maintime.inicio = true;
            }
        }
        else
        {
            _timeLeft = 3;
            RefereeTimer.GetComponent<Text>().text = "";
        }

    }

}
