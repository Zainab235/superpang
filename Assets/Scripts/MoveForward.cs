using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    //public SpawnManager spawnScript;
    // Start is called before the first frame update
    void Start()
    {
        //spawnScript = GameObject.Find("Smallball").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        //if (spawnScript.isSmall == true)
        //{
        //    transform.Translate(Vector3.down * Time.deltaTime * speed);

        //}
    }
}
