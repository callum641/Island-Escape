using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    private Slider healthBar;
    public int currentHealth = 3;
	// Use this for initialization
	void Start () {
        //get the slider component from this object
        healthBar = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        //set the value of healthBar to currentHealth
        healthBar.value = currentHealth;
	}

   //function to change currentHealth based on the parameter
    public void ChangeHealth(int health)
    {
        currentHealth += health;
    }
}
