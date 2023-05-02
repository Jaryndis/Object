using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text txtHealth;
    [SerializeField] TMP_Text txtScore;
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        player.OnHealthUpdate += UpdateHealth;
    }

    private void OnDisable()
    {
        player.OnHealthUpdate -= UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float currentHealth)
    {
        txtHealth.SetText(currentHealth.ToString());
    }

    public void UpdateScore()
    {
        txtScore.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }
}
