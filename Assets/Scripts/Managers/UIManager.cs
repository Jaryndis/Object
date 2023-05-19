using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text txtHealth;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] TMP_Text txtHighScore;
    [SerializeField] TMP_Text txtMenuHighScore;
    [SerializeField] Player player;

    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject lblGameOverText;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameManager.GetInstance().scoreManager;
        txtMenuHighScore.SetText($"High score {scoreManager.GetHighScore()}");
        //txtHighScore.SetText(scoreManager.GetHighScore().ToString());

        GameManager.GetInstance().OnGameStart += GameStarted;
        GameManager.GetInstance().OnGameEnd += GameOver;

        //player.health.OnHealthUpdate += UpdateHealth;
    }

    private void OnDisable()
    {
        //player.health.OnHealthUpdate -= UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString());
    }

    public void GameStarted()
    {
        txtScore.SetText("0");

        player = GameManager.GetInstance().GetPlayer();
        player.health.OnHealthUpdate += UpdateHealth;

        menuCanvas.SetActive(false);
    }

    public void GameOver()
    {
        player.health.OnHealthUpdate -= UpdateHealth;

        lblGameOverText.SetActive(true);
        menuCanvas.SetActive(true);
    }

    public void UpdateScore()
    {
        //txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
        txtScore.SetText(scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        //txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
        txtHighScore.SetText(scoreManager.GetHighScore().ToString());
        txtMenuHighScore.SetText($"High score {scoreManager.GetHighScore()}");
    }
}
