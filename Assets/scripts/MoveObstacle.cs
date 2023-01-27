using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speedOfObstical;
    [SerializeField] private float minX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speedOfObstical * Time.deltaTime);
        if(transform.position.x < minX)
            Destroy(gameObject);
    }
}
