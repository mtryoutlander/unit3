using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speedOfObstical;
    [SerializeField] private float minX;
    
    private void Start()
    {
        PlayerControls.OnHit += DestoryParent;
        CanvasControler.EndGame += DestoryParent;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speedOfObstical * Time.deltaTime);
            if (transform.position.x < minX)
                Destroy(transform.parent.gameObject);
       
    }
    private void OnDestroy()
    {
        PlayerControls.OnHit -= DestoryParent;
        CanvasControler.EndGame -= DestoryParent;
    }
    private void DestoryParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
