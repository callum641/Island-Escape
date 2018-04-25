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
    float time = 0f;
    float timepassed;
    float time2 = 0f;
    float random;
    float switchState;
    float speed = 3f;
    Vector3[] path;
    int targetIndex;
    Vector3 euler;
    Vector3 direction;
    float randomState;
    bool objectDetected = false;

    float RotationSpeed = 1f;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        enemyController = transform.parent.gameObject.GetComponent<EnemyController>();
        switchState = Random.Range(6, 10);
        random = Random.Range(11, 14);
        randomState = Random.Range(0, 10);
        
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
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Player")
                {
                    enemyController.MoveToPlayer();
                    
                }
                else if (hit.collider.tag == "Collision")
                {
                    PathRequestManager.RequestPath(enemyController.transform.position, target.position, OnPathFound);

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
            }

        }
        }
    


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
        targetIndex = 0;
        Vector3 currentWaypoint = path[0];
        while (true)
            {
                if (enemyController.transform.position == currentWaypoint)
                {
                    targetIndex++;
                if (targetIndex >= path.Length)
                    {
                    
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


