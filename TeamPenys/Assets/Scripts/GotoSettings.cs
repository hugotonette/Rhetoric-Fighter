using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSettings : MonoBehaviour
{
    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
