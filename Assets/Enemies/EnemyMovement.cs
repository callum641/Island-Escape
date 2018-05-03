using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    RaycastHit2D hit;
    public LayerMask collisionLayer;
    public Color raycolor;
    Transform target;
    bool follow;
    EnemyController enemyController;
    EnemyFactory enemyFactory;
    float timepassed;
    float time = 0f;
    float random;
    float switchState;
    private int random2;
    float speed = 3f;
    Vector3[] path;
    int targetIndex;
    Vector3 euler;
    Vector3 direction;
    private bool seePlayer;
    private bool pathComplete = true;
    private float distance;
    private bool lowHealth = false;

    // Use this for initialization
    void Start()
    {
        //setting starting variables and finding objects to be referenced later
        target = GameObject.FindWithTag("Player").transform;
        enemyController = transform.parent.gameObject.GetComponent<EnemyController>();
        enemyFactory = GameObject.FindGameObjectWithTag("Respawn").GetComponent<EnemyFactory>();
        switchState = Random.Range(6, 10);
        random = Random.Range(11, 14);
        random2 = Random.Range(0, 20);
    }

   



    // Update is called once per frame
    void Update()
    {
        //finding the direction of the target and comparing to the rotation of the enemy to find the angle
        Vector3 targetDir = target.position - transform.position;
        Vector3 direction = enemyController.transform.localRotation * Vector3.right;
        float angle = Vector3.Angle(targetDir, direction);
        //Uses the distance method to find distance between target and enemy position
        distance = Vector3.Distance(target.position, transform.position);
        //low health states
        if (random2 >= 10 && enemyController.healthLow == true)
        {
            lowHealth = true;
            enemyFactory.SpawnHelp();
        }
        else if (random2 < 10 && enemyController.healthLow == true)
        {
            lowHealth = true;
            enemyController.Run();
        }
        else if (distance > 9f)
        {
            random2 = Random.Range(0, 20);
        }
        //if player is in line of sight
        if (angle < 60f && distance < 9f && lowHealth == false)
            {
            //create ray in direction of the player from the enemy
            Vector3 rayDirection = target.transform.position - transform.position;
            //visual representation of ray for debugging
                Debug.DrawRay(transform.position, rayDirection, raycolor);
                hit = Physics2D.Raycast(transform.position, rayDirection, 8, collisionLayer);
            //if statements based on the return of the ray
                if (hit.collider != null)
                {
                //if the player was hit break A* path and follow
                    if (hit.collider.tag == "Player")
                    {
                    seePlayer = true;
                    pathComplete = true;

                    enemyController.MoveToPlayer();
                    }
                    //if a collision object is hit start A* path
                    else if (hit.collider.tag == "Collision")
                    {
                        seePlayer = false;
                        PathRequestManager.RequestPath(enemyController.transform.position, target.position, OnPathFound);
                    }
                }
                //if path is complete but player is not visible return to normal wander path
                else if (pathComplete == true)
                {
                time += Time.deltaTime;
                    if (time < switchState)
                    {

                        enemyController.Wander();
                    }
                    else if (time > switchState && time < random)
                    {

                        enemyController.Stay();
                    }
                    else
                    {
                        time = 0;
                        switchState = Random.Range(6, 10);
                        random = Random.Range(12, 16);
                    }

                }


            }
        //if path is complete and distance between player and enemy is greater than 9f carry on wandering
            else if (pathComplete == true && distance > 9f)
            {
            time += Time.deltaTime;
                if (time < switchState)
                {

                    enemyController.Wander();
                }
                else if (time > switchState && time < random)
                {


                    enemyController.Stay();
                }
                else
                {
                    time = 0;
                    switchState = Random.Range(6, 10);
                    random = Random.Range(11, 14);
                }

            }
        
        }
    

    //Following code is the same code found in the unit class
        public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
        {
            if (pathSuccessful)
            {
            path = newPath;
                targetIndex = 0;
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }

        IEnumerator FollowPath()
        {
        pathComplete = false;
        targetIndex = 0;
        Vector3 currentWaypoint = path[0];
        while (seePlayer == false)
            {
            if (enemyController.transform.position == currentWaypoint)
                {
                    targetIndex++;
                if (targetIndex >= path.Length)
                    {
                    pathComplete = true;
                    targetIndex = 0;
                    path = new Vector3[0];
                    yield break;
                    }
                    currentWaypoint = path[targetIndex];
                }

            Vector3 targetDir = currentWaypoint - enemyController.transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            enemyController.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            enemyController.transform.position = Vector3.MoveTowards(enemyController.transform.position, currentWaypoint, speed * Time.deltaTime);
                yield return null;
            }
        }

        public void OnDrawGizmos()
        {
            if (path != null)
            {
                for (int i = targetIndex; i < path.Length; i++)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(path[i], Vector3.one);

                    if (i == targetIndex)
                    {
                        Gizmos.DrawLine(transform.position, path[i]);
                    }
                    else
                    {
                        Gizmos.DrawLine(path[i - 1], path[i]);
                    }
                }
            }
        }
    
}


