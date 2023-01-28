using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    public float jumpForce =5f, gravity = 1f, pushBack = 5;
    public delegate void PlayerHitObstical();
    public static event PlayerHitObstical OnHit;
    private Animator animation;
    
    private bool inAir=false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        animation= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            inAir = true;
            animation.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            inAir = false;
            animation.ResetTrigger("Jump_trig");
        }
        if(collision.gameObject.tag == "gameOver")
        {
            if (OnHit != null)
            {
                OnHit();
                Debug.Log("player hit event");
            }

        }
        if (collision.gameObject.tag == "obstical")
        {
            Debug.Log("hit obstical");
            Destroy(collision.gameObject);
            transform.position = new Vector3(transform.position.x-pushBack, transform.position.y, transform.position.z);
        }

    }
}
