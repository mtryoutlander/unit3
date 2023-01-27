using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{

    public GameObject[] obsticals;
    public float spawnIntval=3, startTime=3;
    public GameObject spawnPont;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstical",startTime,spawnIntval);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void SpawnObstical()
    {
        Instantiate(obsticals[UnityEngine.Random.Range(0, obsticals.Length)], spawnPont.transform);
    }
}
