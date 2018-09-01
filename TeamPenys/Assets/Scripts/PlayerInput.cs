using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public HPBar HPBarScript;
    public ComboPrompt ComboPromptScript;
    public KeyCode ConfirmKey;
    [HideInInspector] public bool VerifyResult = false;

    private List<KeyCode> _playerInputs = new List<KeyCode>();
    private int count = 0;
    private int Signal = 1;

    private bool VerifyInput(List<KeyCode> original, List<KeyCode> player)
    {
        for (int i = 0; i < original.Count; i++)
        {
            if (original[i] != player[i])
                return false;
        }
        return true;
    }

    private void Update()
    {
        // RECEBE INPUT DO PLAYER
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
                VerifyResult = VerifyInput(ComboPromptScript.InputsChosen, _playerInputs);

                if (VerifyResult)
                {
                    Debug.Log("Correct");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value + (Signal * HPBarScript.Damage);
                    //NewRound();
                }
                else
                {
                    Debug.Log("Wrong");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                    //NewRound();
                }
            }
            else
            {
                Debug.Log("Wrong");
                HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                //NewRound();
            }
        }
    }
}
