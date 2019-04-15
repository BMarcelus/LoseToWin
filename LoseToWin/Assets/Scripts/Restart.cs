using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour 
{
    public void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("BeginningScene");
    }
}


