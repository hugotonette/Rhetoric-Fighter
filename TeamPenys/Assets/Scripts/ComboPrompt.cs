using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboPrompt : MonoBehaviour
{
    /*
    public Fights FightsScript;
    public bool LeftSide = true;
    */

    public KeyCode[] ComboInput;                                                                         // What inputs to recognize ***
    [Tooltip("Needs to be in the same order as ComboInput")] public Sprite[] InputSprites;               // Images to use (need to put in the same order as ComboInput ***
    

    [HideInInspector] public Image[] CanvasInputSprites;                                                                // Get Images of the canvas ***
    [HideInInspector] public List<KeyCode> InputsChosen = new List<KeyCode>();                                          // Inputs to the player to enter
    
    
    private int GetRandomInputKey(int size)
    {
        return Random.Range(0, size);
    }

    private void RandomInputs()
    {
        if (CanvasInputSprites != null)
        {
            foreach (Image image in CanvasInputSprites)
            {
                int num = GetRandomInputKey(ComboInput.Length);
                image.sprite = InputSprites[num];
                InputsChosen.Add(ComboInput[num]);
            }
        }
    }
    
    private void Start()
    {
        /*
        if (LeftSide == true)
            Signal = 1;
        else
            Signal = -1;
            */
        CanvasInputSprites = GetComponentsInChildren<Image>();

        //NewRound();    CHANGE TO WORK IN THE GAME MANAGER
    }
}