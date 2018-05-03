using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalking : MonoBehaviour {
    public float moveSpeed = 1.0f;


    // Use this for initialization
    void Start () {
      
    }

    // Update is called once per frame
    void Update()
    {
        //get the rigidbody component from this object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //if statements checkign for each key press and adding force in the relevant direction based on the key press.
        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.up * 7);
            
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-transform.up * 7);
            
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(transform.right * 7);
            
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-transform.right * 7);
            
        }

    }
}

