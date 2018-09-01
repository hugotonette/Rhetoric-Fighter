using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPrompt : MonoBehaviour
{
    public HPBar HPBarScript;
    public GameObject RefereeTimer;
    [Range(0, 5)] public float RefereeTime = 3;
    public bool LeftSide = true;
    public KeyCode ConfirmKey;
    public KeyCode[] ComboInput;                                                                         // What inputs to recognize
    [Tooltip("Needs to be in the same order as ComboInput")] public Sprite[] InputSprites;               // Images to use (need to put in the same order as ComboInput
    [HideInInspector] public bool VerifyResult = false;

    private Image[] _canvasInputSprites;                                                                // Get Images of the canvas
    private List<KeyCode> _inputsChosen = new List<KeyCode>();                                          // Inputs to the player to enter
    private List<KeyCode> _playerInputs = new List<KeyCode>();
    private int count = 0;
    private int Signal = 1;
    private bool RefereeCountdown;
    private float _RefereeTimeLeft;


    IEnumerator WaitBetweenRounds()
    {
        RefereeCountdown = true;
        RefereeTimer.SetActive(true);
        yield return new WaitForSeconds(RefereeTime);
        RefereeTimer.SetActive(false);
        RefereeCountdown = false;
    }

    private int GetRandomInputKey(int size)
    {
        return Random.Range(0, size);
    }

    private bool VerifyInput(List<KeyCode> original, List<KeyCode> player)
    {
        for (int i = 0; i < original.Count; i++)
        {
            if (original[i] != player[i])
                return false;
        }
        return true;
    }

    private void RandomInputs()
    {
        if (_canvasInputSprites != null)
        {
            foreach (Image image in _canvasInputSprites)
            {
                int num = GetRandomInputKey(ComboInput.Length);
                image.sprite = InputSprites[num];
                _inputsChosen.Add(ComboInput[num]);
            }
        }
    }

    private void NewRound()
    {
        WaitBetweenRounds();
        RandomInputs();
    }

    private void Start()
    {
        if (LeftSide == true)
            Signal = 1;
        else
            Signal = -1;

        _canvasInputSprites = GetComponentsInChildren<Image>();

        NewRound();
    }

    private void Update()
    {
        if (RefereeCountdown)
        {
            if (_RefereeTimeLeft >= 0)
            {
                _RefereeTimeLeft = _RefereeTimeLeft - Time.deltaTime;
                RefereeTimer.GetComponent<Text>().text = Mathf.Round(_RefereeTimeLeft).ToString();
            }
        }

        if (count < _canvasInputSprites.Length)
            foreach (KeyCode key in ComboInput)
                if (Input.GetKeyDown(key))
                {
                    Debug.Log(key);
                    _playerInputs.Add(key);
                    count++;
                }

        if (Input.GetKeyDown(ConfirmKey))
        {
            if (_playerInputs.Count == _inputsChosen.Count)
            {
                VerifyResult = VerifyInput(_inputsChosen, _playerInputs);

                if (VerifyResult)
                {
                    Debug.Log("Correct");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value + (Signal * HPBarScript.Damage);
                    NewRound();
                }
                else
                {
                    Debug.Log("Wrong");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                    NewRound();
                }
            }
            else
            {
                Debug.Log("Wrong");
                HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                NewRound();
            }
        }
    }
}