using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent OnScoreUpdated;

    int score;


    public int GetScore()
    {
        return score;
    }

    public void IncrementScore()
    {
        score++;
        OnScoreUpdated?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
