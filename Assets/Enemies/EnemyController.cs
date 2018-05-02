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
        target = GameObject.FindWithTag("Player").transform;
        duration = Random.Range(1, 7);
        euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        distance = Vector3.Distance(target.position, transform.position);
        characterController = target.gameObject.GetComponent<CharacterController>();
        Wander();

    }

    // Update is called once per frame
    void Update()
    {
        time2 += Time.deltaTime;
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 3f && healthLow == false)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
        if (health == 1 && distance <8f)
        {
            healthLow = true;  
        }
        else
        {
            healthLow = false;
        }
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


        public void MoveToPlayer()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
        
    public void Run()
    {
        transform.LookAt(2 * transform.position - target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    public void Stay()
    {
            transform.position = transform.position;
    }

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
    

