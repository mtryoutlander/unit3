using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public float jumpForce =5f, gravity = 1f, pushBack = 5;
    public delegate void PlayerHitObstical();
    public static event PlayerHitObstical OnHit;
    public ParticleSystem explosionPartical, dirtPartical;
    public AudioClip jump, crash;

    private AudioSource playerAudio;
    private Animator animation;
    private bool inAir=false;
    private Rigidbody rb;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver= false;
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        animation= GetComponent<Animator>();
        playerAudio= GetComponent<AudioSource>();
        CanvasControler.EndGame+= GameOver;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtPartical.Stop();
            inAir = true;
            playerAudio.PlayOneShot(jump);
            animation.SetTrigger("Jump_trig");
        }
        if (transform.position.x < -8)
            OnHit();
        if(Input.GetKeyDown(KeyCode.R) && !!gameOver)
        {
            SceneManager.LoadScene("Prototype 3");
        }
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(inAir)
            if (collision.gameObject.tag == "floor")
            {
                inAir = false;
                dirtPartical.Play();
                animation.ResetTrigger("Jump_trig");
            }
        if (collision.gameObject.tag == "obstical")
        {
            playerAudio.PlayOneShot(crash);
            explosionPartical.Play();
            transform.position = new Vector3(transform.position.x - pushBack, transform.position.y, transform.position.z);
            Destroy(collision.transform.parent.gameObject);
            
        }

    }
    private void GameOver()
    {
        gameOver = true;
    }
}
