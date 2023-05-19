using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public UnityEvent OnScoreUpdated;
    public UnityEvent OnHighScoreUpdated;

    int score;
    int highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
        OnHighScoreUpdated?.Invoke();
        GameManager.GetInstance().OnGameStart += OnGameStart;
    }

    public int GetScore()
    {
        return score;
    }
    public int GetHighScore()
    {
        return highscore;
    }

    public void IncrementScore()
    {
        score++;
        OnScoreUpdated?.Invoke();

        if(score > highscore)
        {
            highscore = score;
            OnHighScoreUpdated?.Invoke();
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
    }

    public void OnGameStart()
    {
        score = 0;
        //highscore = 0;
    }
}
