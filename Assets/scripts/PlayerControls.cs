using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    public float jumpForce =5f, gravity = 1f;
    public delegate void PlayerHitObstical();
    public static event PlayerHitObstical OnHit;
    
    
    private bool inAir=false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inAir = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
            inAir= false;
        if(collision.gameObject.tag == "obstical")
        {
            if (OnHit != null)
            {
                OnHit();
                Debug.Log("player hit event");
            }

        }

    }
}
