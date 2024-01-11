using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool isCollided;
    static int collide = 0;
    public AudioClip collisionSound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
         if (collision.gameObject.CompareTag("Gun"))
            {
             collide = collide + 1;
             Debug.Log("Score:  " + collide);
            isCollided = true;
            
            Destroy(gameObject);
            


            }
    }
  
 }
