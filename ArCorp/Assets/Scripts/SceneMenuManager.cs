using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);  
    }
    public void StartAnatomia()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
