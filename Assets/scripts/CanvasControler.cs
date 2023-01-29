using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    private Text gameOverText, timmer;
    private float gameTimer =0;
    private bool gameOver;
    public delegate void GameOverEvent();
    public static event GameOverEvent EndGame;
    private void OnEnable()
    {
        PlayerControls.OnHit += GameOver;
    }

    private void Start()
    {
        gameOverText= GetComponentInChildren<Text>();
        gameOverText.enabled=false;
        timmer = GetComponentsInChildren<Text>()[1];

    }
    private void Update()
    {
        if (!gameOver)
        {
            gameTimer += Time.deltaTime;
            timmer.text = gameTimer.ToString();
        }
    }
    private void GameOver()
    {
        gameOver= true;
        gameOverText.enabled= true;
        if(EndGame != null)
            EndGame();

    }
}
