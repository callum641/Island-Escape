using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    float speed = 4.5f;
    public float attack1Range = 0.1f;
    public int attack1Damage = 1;
    public float timeBetweenAttacks;
    float randomX;
    float randomY;
    float time = 0f;
    float duration;
   

    // Use this for initialization
    void Start()
    {
        randomX = Random.Range(-3, 3);
        randomY = Random.Range(-3, 3);
        duration = Random.Range(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPlayer()
    {
        //rotate to look at player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        
    }

    public void Wander()
    {
        if (time < duration)
        {
            transform.Translate(new Vector3(randomX, randomY, 0) * Time.deltaTime);
            
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
            randomX = Random.Range(-3, 3);
            randomY = Random.Range(-3, 3);
            duration = Random.Range(0, 10);
        }
    }
}