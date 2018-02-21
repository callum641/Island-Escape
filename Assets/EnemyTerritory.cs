using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour {

    public BoxCollider territory;
    GameObject player;
    bool playerInTerritory;

    public GameObject enemy;
    EnemyController enemycontroller;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemycontroller = transform.parent.gameObject.GetComponent<EnemyController>();
        playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTerritory == true)
        {
            enemycontroller.MoveToPlayer();
        }

        if (playerInTerritory == false)
        {
            enemycontroller.Rest();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInTerritory = false;
        }
    }
}
