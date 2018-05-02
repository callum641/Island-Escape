using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D[] colliders;
    private bool isInvincible = false;
    private float timeSpentInvincible;
    public BoxCollider2D enemyContact;
    private HealthBarController healthBar;
    float distance;
    Transform target;
    public int amount;
    private EnemyController enemyController;
    private UIManager uiManager;
    public List<Transform> spawners;
    private GameObject rotation;
    public int score;


    // Use this for initialization
    void Start()
    {
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
        rotation = GameObject.Find("Rotation");
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
        spawners.Clear();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            spawners.Add(go.GetComponent<Transform>());
        }
        if (spawners.Count > 0) { 
        target = GetClosestEnemy(spawners);
        enemyController = target.gameObject.GetComponent<EnemyController>();
        distance = Vector3.Distance(target.position, transform.position);
        Vector3 targetDir = target.position - transform.position;
        Vector3 direction = rotation.transform.localRotation * Vector3.right;
        float angle = Vector3.Angle(targetDir, direction);
            if (distance < 4f && angle <60f)
        {
            enemyController.TakeDamage(-1);
        }
    }
    }

   public void IncreaseScore(int amount)
    {
        score += amount;
        uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        uiManager.SetScore(score);
        if (healthBar.currentHealth < 3)
        {
            healthBar.changeHealth(1);
        }
        if (score >= 10)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }

    //Gotten from unity forum as a means to calculate distance between an array of enemies and Player
    Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
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


