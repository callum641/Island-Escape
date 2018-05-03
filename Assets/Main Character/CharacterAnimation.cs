using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    public Sprite[] sprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;
    private GameObject rotation;


    public bool IsKeyEnabled_w { get; set; }
    public bool IsKeyEnabled_a { get; set; }
    public bool IsKeyEnabled_s { get; set; }
    public bool IsKeyEnabled_d { get; set; }

    // Use this for initialization
    void Start () {
        //getting game objects for use later
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        rotation = GameObject.Find("Rotation");
        //setting the character to be awake
        Awake();
    }

    //function to allow all key presses
    void Awake()
    {
        IsKeyEnabled_w = true;
        IsKeyEnabled_a = true;
        IsKeyEnabled_s = true;
        IsKeyEnabled_d = true;
    }


    // Update is called once per frame
    void Update()
        {
        //if statements checking for relevant keypress and only allowing one key to be activated at a time
        //it then loops through an array of sprites to create the walking animation as well as setting the rotation of the rotation object
        if (Input.GetKey("a") && IsKeyEnabled_a == true)
            {
                IsKeyEnabled_w = false;
                IsKeyEnabled_s = false;
                IsKeyEnabled_d = false;
                int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
                index = index % 6 + 1;
                spriteRenderer.sprite = sprites[index];
                rotation.transform.eulerAngles = new Vector3(0, 180, 0);


        }
        else if (Input.GetKey("d") && IsKeyEnabled_d == true)
        {
            IsKeyEnabled_w = false;
            IsKeyEnabled_s = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 6 + 7;
            spriteRenderer.sprite = sprites[index];
            rotation.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("s") && IsKeyEnabled_s == true)
        {
            IsKeyEnabled_w = false;
            IsKeyEnabled_d = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 5 + 13;
            spriteRenderer.sprite = sprites[index];
            rotation.transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (Input.GetKey("w") && IsKeyEnabled_w == true)
        {
            IsKeyEnabled_s = false;
            IsKeyEnabled_d = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 3 + 18;
            spriteRenderer.sprite = sprites[index];
            rotation.transform.eulerAngles = new Vector3(0, 0, 90);
        }
       
        //when a key is released sets the other keys to active again
        if (Input.GetKeyUp("d"))
        {
            Awake();
        }
        else if (Input.GetKeyUp("a"))
        {
            Awake();
        }
        else if (Input.GetKeyUp("s"))
        {
            Awake();
        }
        else if (Input.GetKeyUp("w"))
        {
            Awake();
        }
    }
}
