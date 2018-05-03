using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;
    float speed = 4.5f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;
    CharacterController characterController;
    public int health;
    float time = 0;
    float duration;
    Vector3 euler;
    float distance;
    private bool isInvincible = false;
    private float timeSpentInvincible;
    private float time3;
    public bool healthLow;
    private float time2;


    // Use this for initialization
    void Start()
    {
        //Setting starting variables and finding objects to be used later
        target = GameObject.FindWithTag("Player").transform;
        duration = Random.Range(1, 7);
        euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        distance = Vector3.Distance(target.position, transform.position);
        characterController = target.gameObject.GetComponent<CharacterController>();
        //setting first state to be wander
        Wander();

    }

    // Update is called once per frame
    void Update()
    {
        //if the player gets too close turn to look at them
        time2 += Time.deltaTime;
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 3f && healthLow == false)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
        //if health is too low and the player is close activate health low states
        if (health == 1 && distance <8f)
        {
            healthLow = true;  
        }
        else
        {
            healthLow = false;
        }
        //when the enemy is hit and turned invincible, this makes the enemy sprite flash and counts down time left invincible
        if (isInvincible)
        {

            timeSpentInvincible += Time.deltaTime;


            if (timeSpentInvincible < 2f)
            {
                float remainder = timeSpentInvincible % .3f;
                GetComponent<Renderer>().enabled = remainder > .15f;
            }

            else
            {
                GetComponent<Renderer>().enabled = true;
                isInvincible = false;
            }
        }
    }
    //TakeDamage() function is called by the player when the enemy is hit, turns them invincible if not already and takes health away
    //when health hits 0 destryos the game object and calls the IncreaseScore() function
    public void TakeDamage(int amount)
    {
        
        if (!isInvincible)
        {
            isInvincible = true;
            timeSpentInvincible = 0;
            health += amount;
            Debug.Log("enemy health" + health);
            if (health == 0)
            {
                Destroy(this.gameObject);
                characterController.IncreaseScore(1);

            }
        }
    }

    //move to player state, looks at the player and moves towards
        public void MoveToPlayer()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
        
    //run state, opposite of move to player as it looks away from player and moves towards
    public void Run()
    {
        transform.LookAt(2 * transform.position - target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
    //stay state, sets enemy position to itself so that it stops
    public void Stay()
    {
            transform.position = transform.position;
    }
    //wander state, based on random amount of time will rotate to a new direction and move forwards
    public void Wander()
    {
            if (time < duration)
            {
                transform.eulerAngles = euler;
                transform.position += transform.right * speed * Time.deltaTime;
                time += Time.deltaTime;
            }
            else if (time > duration)
            {
                time = 0f;
                duration = Random.Range(2, 4);
                euler.z = Random.Range(0f, 360f);
            }
        }
    //collison with the walls
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Left Wall"))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
        else if (other.CompareTag("Bottom Wall"))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
}
    

