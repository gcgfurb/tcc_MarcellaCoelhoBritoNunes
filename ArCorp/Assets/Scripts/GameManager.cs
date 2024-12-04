using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Vuforia;
using System;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static string statusGame;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public List<string> questions;       
    public List<GameObject> imageTargets; 
    private List<int> askedQuestions = new List<int>(); 

    public float timer;
    private int qtdeQuestions;
    private int currentQuestionIndex;
    private IEnumerator coroutine;

    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
       score = 0; 
       timer = 50f; 
       statusGame = "Play";
       qtdeQuestions = questions.Count;
       coroutine = WaitTimer();
       StartCoroutine(coroutine);
       ShowQuestion();
    }

    public void ShowQuestion(){
        if (askedQuestions.Count < qtdeQuestions)
        {
            do
            {
                currentQuestionIndex = UnityEngine.Random.Range(0, qtdeQuestions);
            }
            while (askedQuestions.Contains(currentQuestionIndex)); 
            askedQuestions.Add(currentQuestionIndex);
            questionText.text = questions[currentQuestionIndex];
            Instantiate(imageTargets[currentQuestionIndex]);
            timer += 10f;
        }
        else
        {
           statusGame = "Win";
           SceneManager.LoadScene(2); 
        }
    }

    private void ShowHud()
    {
        scoreText.text = "SCORE: " + score;
        timerText.text = "TIMER: " + (int)timer;
    }

    private IEnumerator WaitTimer()
    {
        while (statusGame == "Play")
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            ShowHud();
            if (timer <= 0)
            {
                statusGame = "GameOver";
                SceneManager.LoadScene(2); 
            }
        }
    }
    public void OnImageRecognized()
    {
        if (statusGame == "Play"){
            ShowQuestion();
        }
    }
}
