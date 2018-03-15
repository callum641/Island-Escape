using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    private Slider healthBar;
    public int currentHealth = 3;
	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = currentHealth;
	}

   
    public void changeHealth(int health)
    {
        currentHealth += health;
    }
}
