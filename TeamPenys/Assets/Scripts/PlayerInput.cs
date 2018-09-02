using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public HPBar HPBarScript;
    public ComboPrompt ComboPromptScript;
    public Fights FightsScript;
    public KeyCode ConfirmKey;
    public bool LeftSide = true;
    [HideInInspector] public bool AbleToClick = false;
    public List<KeyCode> _playerInputs = new List<KeyCode>();

    private int count = 0;
    private int Signal = 1;
    
    private bool VerifyInput(List<KeyCode> original, List<KeyCode> player)
    {
        for (int i = 0; i < original.Count; i++)
            if (original[i] != player[i])
            {
                Debug.Log("Errou Miseravi");
                return false;
            }
        Debug.Log("Acertou Miseravi");
        return true;
    }

    private void Start()
    {
        if (LeftSide == true)
            Signal = 1;
        else
            Signal = -1;
    }

    private void Update()
    {
        // RECEBE INPUT DO PLAYER
        if (AbleToClick)
        {
            if (count < ComboPromptScript.CanvasInputSprites.Length)
                foreach (KeyCode key in ComboPromptScript.ComboInput)
                    if (Input.GetKeyDown(key))
                    {
                        Debug.Log(key);
                        _playerInputs.Add(key);
                        count++;
                    }

            // CHECKA SE TA TUDO CERTO
            if (Input.GetKeyDown(ConfirmKey))
            {
                if (_playerInputs.Count == ComboPromptScript.InputsChosen.Count)
                {
                    if (VerifyInput(ComboPromptScript.InputsChosen, _playerInputs) && ComboPromptScript.InputsChosen.Count != 0)
                    {
                        Debug.Log("Correct");
                        HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value + (Signal * HPBarScript.Damage);
                        count = 0;
                        _playerInputs.Clear();
                        ComboPromptScript.InputsChosen.Clear();
                        FightsScript.NewRound();

                    }
                    else if (!VerifyInput(ComboPromptScript.InputsChosen, _playerInputs) && ComboPromptScript.InputsChosen.Count != 0)
                    {
                        Debug.Log("Wrong");
                        HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                        count = 0;
                        _playerInputs.Clear();
                        ComboPromptScript.InputsChosen.Clear();
                        FightsScript.NewRound();

                    }
                }
                else
                {
                    Debug.Log("Error: Not Full");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                    count = 0;
                    _playerInputs.Clear();
                    ComboPromptScript.InputsChosen.Clear();
                    FightsScript.NewRound();
                }
            }
        }
    }
}
