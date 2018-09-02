using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rematch : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
