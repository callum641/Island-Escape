using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{

    RaycastHit2D hit;
    public LayerMask collisionLayer;
    public Color raycolor;
    GameObject player;
    bool follow;
    EnemyController enemycontroller;
    public Transform target;

    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemycontroller = transform.parent.gameObject.GetComponent<EnemyController>();
        enemycontroller.Wander();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemycontroller.transform.LookAt(target.position);
            enemycontroller.transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
    }

       
            // Update is called once per frame
            void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 direction = enemycontroller.transform.localRotation * Vector3.right;
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

                enemycontroller.MoveToPlayer();
            }
            else if (hit.collider.tag == "Rock")
                {
                    enemycontroller.Wander();
                }
                }
        else if (hit.collider == null)
        {

            enemycontroller.Wander();
        }
        }
        else
        {
            enemycontroller.Wander();
        }
    }
    }

