using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneGameOverManager : MonoBehaviour
{
    public TextMeshProUGUI statusGameText;
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        scoreText.text = "SCORE: " + GameManager.score; 
        if (GameManager.statusGame == "Win")
        {
            statusGameText.text = "Parabéns, você ganhou!";
        }
        else
        {
            statusGameText.text = "Que pena, você perdeu, vamos tentar novamente?";
        }
        Invoke("GoToMenu",5f);
    }

   private void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
