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
    [HideInInspector] public List<KeyCode> _playerInputs = new List<KeyCode>();
    public Animator P_anim;
    public Animator P_animOther;
    public GameObject player;

    private int count = 0;
    private int Signal = 1;
    
    private bool VerifyInput(List<KeyCode> original, List<KeyCode> player)
    {
        for (int i = 0; i < original.Count; i++)
            if (original[i] != player[i])
            {
                return false;
            }
        return true;
    }
    

    private void Start()
    {
        P_anim = player.GetComponent<Animator>();
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
                    if (VerifyInput(ComboPromptScript.InputsChosen, _playerInputs) /*&& ComboPromptScript.InputsChosen.Count != 0*/)
                    {
                        AbleToClick = false;
                        Debug.Log("Correct");
                        HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value + (Signal * HPBarScript.Damage);
                        P_anim.SetTrigger("Golpeando");
                        P_animOther.SetTrigger("Hit");
                        count = 0;
                        _playerInputs.Clear();
                        ComboPromptScript.InputsChosen.Clear();
                        FightsScript.NewRound();

                    }
                    else if (!VerifyInput(ComboPromptScript.InputsChosen, _playerInputs) && ComboPromptScript.InputsChosen.Count != 0)
                    {
                        AbleToClick = false;
                        Debug.Log("Wrong");
                        HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                        P_anim.SetTrigger("Hit");
                        P_animOther.SetTrigger("Golpeando");
                        count = 0;
                        _playerInputs.Clear();
                        ComboPromptScript.InputsChosen.Clear();
                        FightsScript.NewRound();

                    }
                }
                else
                {
                    AbleToClick = false;
                    Debug.Log("Error: Not Full");
                    HPBarScript.GetComponent<Slider>().value = HPBarScript.GetComponent<Slider>().value - (Signal * HPBarScript.Damage);
                    P_anim.SetTrigger("Hit");
                    P_animOther.SetTrigger("Golpeando");
                    count = 0;
                    _playerInputs.Clear();
                    ComboPromptScript.InputsChosen.Clear();
                    FightsScript.NewRound();
                }
            }
        }
    }
}
