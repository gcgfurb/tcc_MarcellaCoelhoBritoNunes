using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargets : MonoBehaviour
{
    public void GoNextQuestion()
    {
        Invoke("NextQuestion", 5f);
    }
    public void GoNextQuestion10()
    {
        Invoke("NextQuestion", 10f);
    }
    public void GoNextQuestion20()
    {
        Invoke("NextQuestion", 20f);
    }
    private void NextQuestion()
    {
        GameManager.score += 50;

        GameObject.Find("GameManager").GetComponent<GameManager>().ShowQuestion();
        Destroy(gameObject);
    }
}
