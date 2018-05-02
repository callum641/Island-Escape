using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject Enemy;
    int wait = 3;
    int canrespawn;
    int canspawn = 10;
    float time;
    float randx, randy;
    GameObject[] enemys;
    float time2;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        time += Time.deltaTime;
        wait =+ Random.Range(5, 15);
        canrespawn = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void SpawnHelp()
    {
        if (canrespawn < 5)
        {
            time2 += Time.deltaTime;
            if (time2 > 5)
            {
                randx = Random.Range(-9, 30);
                randy = Random.Range(-14, 25);
                GameObject clone = Instantiate(Enemy, new Vector3(randx, randy), transform.rotation);
                time2 = 0;
            }
        }
        }

    public void Spawn()
    {
        if (canrespawn < 5)
        {
            if (time >= canspawn)
            {
                randx = Random.Range(-9, 30);
                randy = Random.Range(-14, 25);
                GameObject clone = Instantiate(Enemy, new Vector3(randx, randy), transform.rotation);
                canspawn += wait;
            }
        }
    }
}

