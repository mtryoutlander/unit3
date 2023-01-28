using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{

    public GameObject[] obsticals;
    public float spawnIntval=3, startTime=3;
    public GameObject spawnPont;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstical), startTime, spawnIntval);
        PlayerControls.OnHit += endSpawn;
    }

    private void SpawnObstical()
    {
        if (!gameOver)
        {
            Instantiate(obsticals[UnityEngine.Random.Range(0, obsticals.Length)], spawnPont.transform);
        }
    }
    private void endSpawn()
    {
        gameOver= true;
    }
}
