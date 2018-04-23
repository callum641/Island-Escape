using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{

    RaycastHit2D hit;
    public LayerMask collisionLayer;
    public Color raycolor;
    Transform target;
    bool follow;
    EnemyController enemyController;
    float time = 0f;
    float timepassed;
    float time2 = 0f;
    float random;
    float switchState;


    Vector3 direction;
    private int randomState;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        enemyController = transform.parent.gameObject.GetComponent<EnemyController>();
        switchState = Random.Range(6, 10);
        random = Random.Range(11, 14);
        randomState = Random.Range(0, 10);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Left Wall"))
        {
            transform.Translate(0.5f, 0, 0);
        }
        else if (other.CompareTag("Bottom Wall"))
        {
            transform.Translate(0, 0.5f, 0);
        }
    }



        // Update is called once per frame
        void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 direction = enemyController.transform.localRotation * Vector3.right;
        float angle = Vector3.Angle(targetDir, direction);
        //Debug.Log(angle);
        if (angle < 60f)
        {
            Vector3 rayDirection = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, rayDirection, raycolor);
            hit = Physics2D.Raycast(transform.position, rayDirection, 8, collisionLayer);
            if (hit.collider != null) { 
            if (hit.collider.tag == "Player")
                {
                    if (randomState > 5)
                    {
                        enemyController.RunFromPlayer();
                    }
                    else
                    {
                        enemyController.MoveToPlayer();
                    }
            }
            else if (hit.collider.tag == "Rock")
                {
                    timepassed = 2;

                    if (time > timepassed)
                    {
                        enemyController.Wander();
                    }
                    time += Time.deltaTime;
                }
                }
        else if (hit.collider == null)
        {
              
                time2 += Time.deltaTime;
                if (time2 < switchState)
                {
                   
                    enemyController.Wander();
                }
                else if (time2 > switchState && time2 < random)
                {
                    
                    enemyController.Stay();
                }
                else
                {
                    time2 = 0;
                    switchState = Random.Range(6, 10);
                    random = Random.Range(12, 16);
                }

            }
        }
        else
        {
         
            time2 += Time.deltaTime;
            if (time2 < switchState)
            {
               
                enemyController.Wander();
            }
            else if (time2 > switchState && time2 < random)
            {
               
               
                enemyController.Stay();
            }
            else
            {
                time2 = 0;
                switchState = Random.Range(6, 10);
                random = Random.Range(11, 14);
                randomState = Random.Range(0, 10);
            }

        }
    }
    }

