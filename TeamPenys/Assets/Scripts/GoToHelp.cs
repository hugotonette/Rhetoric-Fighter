using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToHelp : MonoBehaviour
{
    public void ToHelp()
    {
        SceneManager.LoadScene("Help");
    }
}
