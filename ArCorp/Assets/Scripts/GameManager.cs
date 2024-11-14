using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Vuforia;
using System;

public class GameManager : MonoBehaviour
{
    // Dados da classe
    public static int score;
    public static string statusGame;

    // Dados do objeto
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public List<string> questions;       // Lista de perguntas
    public List<GameObject> imageTargets; // Lista de alvos de imagem (modelos 3D ou sprites)

    private List<int> askedQuestions = new List<int>(); // Lista de �ndices de perguntas j� feitas
    public float timer;

    private int qtdeQuestions;
    private int currentQuestionIndex;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        score = 0; // Zera a pontua��o
        timer = 50f; // Define o tempo inicial
        statusGame = "Play";
        qtdeQuestions = questions.Count;
        coroutine = WaitTimer();
        StartCoroutine(coroutine);
        ShowQuestion();
    }

    public void ShowQuestion()
    {
        // Sorteia uma pergunta aleat�ria que ainda n�o foi feita
        if (askedQuestions.Count < qtdeQuestions)
        {
            do
            {
                currentQuestionIndex = UnityEngine.Random.Range(0, qtdeQuestions);
            }
            while (askedQuestions.Contains(currentQuestionIndex)); // Garante que a pergunta n�o foi feita antes

            // Adiciona a pergunta ao hist�rico
            askedQuestions.Add(currentQuestionIndex);

            // Exibe a pergunta e o alvo da imagem
            questionText.text = questions[currentQuestionIndex];
            Instantiate(imageTargets[currentQuestionIndex]);

            // Aumenta o timer em 10 segundos cada vez que uma nova pergunta � exibida
            timer += 10f;
        }
        else
        {
            statusGame = "Win";
            SceneManager.LoadScene(2); // Carrega a cena de vit�ria
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

            // Se o tempo acabar, o jogo termina
            if (timer <= 0)
            {
                statusGame = "GameOver";
                SceneManager.LoadScene(2); // Carrega a cena de game over
            }
        }
    }

    // M�todo chamado quando um ImageTarget � reconhecido
    public void OnImageRecognized()
    {
        if (statusGame == "Play")
        {
            // Avan�a para a pr�xima pergunta assim que um alvo for reconhecido
            ShowQuestion();
        }
    }
}
