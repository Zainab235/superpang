using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float horizontalInput;
    public float speed;
    public float lowerB = 15.5f;
    public float upperB = 55.0f;
    public GameObject projectilePrefab;
    private Animator playerAnim;
    private bool isNotWalking = false;
    private AudioSource playerAudio;
    public AudioClip shootSound;
    public float speedDecayRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        Vector3 movement = transform.TransformDirection(Vector3.right) * horizontalInput * Time.deltaTime * speed;

        // Move the player based on the input along the x-axis
        transform.Translate(movement);
        FlipPlayer();

        if (transform.position.x > upperB)
        {
            transform.position = new Vector3(upperB, transform.position.y, transform.position.z);

        }
        if (transform.position.x < lowerB)
        {
            transform.position = new Vector3(lowerB, transform.position.y, transform.position.z);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //Launch a projectile prefab
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(shootSound, 1.0f);
        }

        if (horizontalInput == 0)
        {
            isNotWalking = true;
            playerAnim.SetBool("IsNotWalking", isNotWalking);
            speed = 0;
            playerAnim.SetFloat("Speed_f", speed);

        }
        else if (horizontalInput > 0 || horizontalInput < 0) {
            speed = 6;
            playerAnim.SetFloat("Speed_f", speed);

        }




    }
    void FlipPlayer()
    {
    //    Quaternion currentRotation = transform.rotation;
        // Flip the player's scale based on the horizontal input
        if (horizontalInput > 0)
        {
            Quaternion newRotation = Quaternion.Euler(0f, 270.0f, 0f);
            transform.rotation = newRotation;
        }
        else if (horizontalInput < 0)
        {
            Quaternion newRotation = Quaternion.Euler(0f, 90.0f, 0f);
            transform.rotation = newRotation;
        }
    }
    
}
