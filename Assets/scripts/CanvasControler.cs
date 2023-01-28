using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    private PlayerControls player;
    private Text gameOverText;
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
    }

    private void GameOver()
    {
        gameOverText.enabled= true;
    }
}
