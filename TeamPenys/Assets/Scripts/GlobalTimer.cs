using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    [Range(0, 99)] public float TimerMax = 99;

    [HideInInspector] public float _timeLeft;

    public bool inicio = false;
    public bool pausado = false;

    public void RestartClock()
    {
        _timeLeft = TimerMax;
    }

    private void Start()
    {
        _timeLeft = TimerMax;
    }

    private void Update()
    {
        if (_timeLeft >= 0 && inicio && !pausado)
        {
            _timeLeft = _timeLeft - Time.deltaTime;
            this.GetComponent<Text>().text = Mathf.Round(_timeLeft).ToString();
        }
    }
}
