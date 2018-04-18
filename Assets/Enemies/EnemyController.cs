using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    float speed = 4.5f;
    float attack1Range = 5f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;
    public int health;
    float time = 0;
    float duration;
    Vector3 euler;
    float distance;
    


    // Use this for initialization
    void Start()
    {

        duration = Random.Range(0, 7);
        euler = transform.eulerAngles;
        euler.z = Random.Range(0f, 360f);
        distance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 3f)
        {
            transform.LookAt(target.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
        
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("enemy health" + health);
        health += amount;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void MoveToPlayer()
    {

        // if (distance > attack1Range){ 
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        // }

        // else if (distance <= attack1Range)
        // {
        //AttackPlayer();
        //  }

    }



    public void AttackPlayer()
    {
        duration = 2f;

        if (time > duration && time < 3f)
        {
            transform.Translate(new Vector3(0f * Time.deltaTime, 0, 0));
            time += Time.deltaTime;

        }
        else if (time < duration)
        {
            if (time < 0.5f)
            {
                transform.Translate(new Vector3(0f * Time.deltaTime, 0, 0));
                time += Time.deltaTime;
            }
            else
            {
                transform.Translate(new Vector3(7f * Time.deltaTime, 0, 0));
                time += Time.deltaTime;
            }
        }
        else if (time > 3f)
        {
            time = 0;

        }

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
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
                //Debug.Log(time);
                //Debug.Log(switchState);
            }
            else if (time > duration)
            {
                time = 0f;
                duration = Random.Range(2, 4);
                euler.z = Random.Range(0f, 360f);
            }
        }
        }
    

