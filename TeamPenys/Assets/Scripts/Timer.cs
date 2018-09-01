using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Range(0, 99)] public float TimerMax = 99;

    private float _timeLeft;

    private void Start()
    {
        _timeLeft = TimerMax;
    }

    private void Update()
    {
        if (_timeLeft >= 0)
        {
            _timeLeft = _timeLeft - Time.deltaTime;
            this.GetComponent<Text>().text = Mathf.Round(_timeLeft).ToString();
        }
    }
}
