using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalking : MonoBehaviour {
    public float moveSpeed = 1.0f;


    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }


        transform.position = pos;
    }
}

