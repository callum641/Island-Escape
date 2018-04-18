using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private bool isInvincible = false;
    private float timeSpentInvincible;
    public PolygonCollider2D enemyContact;
    private HealthBarController healthBar;
    float distance;
    public Transform target;
    public int amount;
    private EnemyController enemyController;


    // Use this for initialization
    void Start()
    {
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("invincible " + isInvincible);
        if (Input.GetMouseButtonDown(0))
        {
            SwordAttack();
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

    void SwordAttack()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 direction = transform.localRotation * Vector3.right;
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 4f)
            {
            enemyController.TakeDamage(-1);
            }

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
            if (!isInvincible && other.CompareTag("Enemy"))
            {
                isInvincible = true;
                timeSpentInvincible = 0;
            healthBar.changeHealth(-1);
                if (healthBar.currentHealth <= 0)
                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
    }


