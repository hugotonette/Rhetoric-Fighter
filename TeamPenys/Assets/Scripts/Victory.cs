using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public void WinGame(int playerNum)
    {
        this.GetComponent<Text>().text = playerNum + "Wins";
    }
}