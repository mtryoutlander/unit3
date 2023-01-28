using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{

    [SerializeField] private float speed =10f;
    private float reapWidth;
    private Vector3 startPos;
    private bool playerBeenHit= false;
    private void Start()
    {
        startPos = transform.position;
        reapWidth = GetComponent<BoxCollider>().size.x/2;
        PlayerControls.OnHit += Stop;
    }
    private void OnEnable()
    {
        PlayerControls.OnHit += Stop;
    }
    private void OnDisable()
    {
        PlayerControls.OnHit -= Stop;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - reapWidth) 
            transform.position = startPos;
        else
            if(!playerBeenHit)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void Stop()
    {
        Debug.Log("event chought");
        playerBeenHit= true;
    }
}
