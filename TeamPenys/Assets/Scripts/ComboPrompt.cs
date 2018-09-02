using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPrompt : MonoBehaviour
{
    public Fights FightsScript;
    public GameObject ComboPromptGameObject;
    public KeyCode[] ComboInput;                                                                         // What inputs to recognize ***
    [Tooltip("Needs to be in the same order as ComboInput")] public Sprite[] InputSprites;               // Images to use (need to put in the same order as ComboInput ***
    [HideInInspector] public Image[] CanvasInputSprites;                                                                // Get Images of the canvas ***
    [HideInInspector] public List<KeyCode> InputsChosen = new List<KeyCode>(4);                                          // Inputs to the player to enter

    private int GetRandomInputKey(int size)
    {
        return Random.Range(0, size);
    }

    public void RandomInputs()
    {
        foreach (Image image in CanvasInputSprites)
        {            if (InputsChosen.Count < ComboPromptGameObject.GetComponentsInChildren<Image>().Length)
            {
                int num = GetRandomInputKey(ComboInput.Length);
                image.sprite = InputSprites[num];
                InputsChosen.Add(ComboInput[num]);
            }
        }
    }

    private void Start()
    {
        CanvasInputSprites = ComboPromptGameObject.GetComponentsInChildren<Image>();
        FightsScript.NewRound();
    }
}