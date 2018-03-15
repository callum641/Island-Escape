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
  

    // Use this for initialization
    void Start()
    {
        healthBar = GameObject.Find("Health Bar").GetComponent<HealthBarController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("invincible " + isInvincible);

       
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
                    SceneManager.LoadScene("Main Scene");
                }
            }
        }
    }


