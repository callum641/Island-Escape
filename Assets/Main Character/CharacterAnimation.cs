using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    public Sprite[] sprites;
    public float framesPerSecond;
    private SpriteRenderer spriteRenderer;
    public bool IsKeyEnabled_w { get; set; }
    public bool IsKeyEnabled_a { get; set; }
    public bool IsKeyEnabled_s { get; set; }
    public bool IsKeyEnabled_d { get; set; }

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        Awake();
    }

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
        if (Input.GetKey("a") && IsKeyEnabled_a == true)
            {
                IsKeyEnabled_w = false;
                IsKeyEnabled_s = false;
                IsKeyEnabled_d = false;
                int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
                index = index % 6 + 1;
                spriteRenderer.sprite = sprites[index];
        }
        else if (Input.GetKey("d") && IsKeyEnabled_d == true)
        {
            IsKeyEnabled_w = false;
            IsKeyEnabled_s = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 6 + 7;
            spriteRenderer.sprite = sprites[index];
        }
        else if (Input.GetKey("s") && IsKeyEnabled_s == true)
        {
            IsKeyEnabled_w = false;
            IsKeyEnabled_d = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 5 + 13;
            spriteRenderer.sprite = sprites[index];
        }
        else if (Input.GetKey("w") && IsKeyEnabled_w == true)
        {
            IsKeyEnabled_s = false;
            IsKeyEnabled_d = false;
            IsKeyEnabled_a = false;
            int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
            index = index % 3 + 18;
            spriteRenderer.sprite = sprites[index];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }
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
