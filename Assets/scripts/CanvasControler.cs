using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    private Text gameOverText, timmer;
    private float gameTimer =0;
    private void OnEnable()
    {
        PlayerControls.OnHit += GameOver;
    }
    private void OnDisable()
    {
        PlayerControls.OnHit -= GameOver;
    }

    private void Start()
    {
        gameOverText= GetComponentInChildren<Text>();
        gameOverText.enabled=false;
        timmer = GetComponentsInChildren<Text>()[1];

    }
    private void Update()
    {
        gameTimer += Time.deltaTime;
        timmer.text = gameTimer.ToString();
    }

    private void GameOver()
    {
        gameOverText.enabled= true;
        
    }
}
