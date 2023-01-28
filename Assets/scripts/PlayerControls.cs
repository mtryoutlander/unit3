using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float jumpForce =5f, gravity = 1f;
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
        inAir= false;
    }
}
