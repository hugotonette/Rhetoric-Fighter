using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightStartTimer : MonoBehaviour
{
    public Text ChildrenText;

    private float _totalTime = 3;
    private float _timeLeft;

    IEnumerator WaitToVanish()
    {
        yield return new WaitForSeconds(1);
        ChildrenText.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
        _timeLeft = _totalTime;
    }

    private void FixedUpdate()
    {
        if(_timeLeft > 0)
        {
            _timeLeft = _timeLeft - Time.deltaTime;
            this.GetComponent<Text>().text = Mathf.Round(_timeLeft).ToString();
            ChildrenText.text = Mathf.Round(_timeLeft).ToString();
        }
        else if(_timeLeft <= 0)
        {
            this.GetComponent<Text>().text = "GO!";
            ChildrenText.text = "GO!";
            StartCoroutine(WaitToVanish());
        }
    }

}
