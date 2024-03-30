using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    public health playerHealth; // contains the players health
    public Image totalHealthbar; //contains the background health bar image
    public Image currentHealthbar; // contains the foreground health bar image
    
    void Start()
    {
        totalHealthbar.fillAmount = playerHealth.currentHealth/10; // initialises the healtbar with the player's startingHealth
    }

    void Update()
    {
        updateHealthbar(); //calls on the update 
    }

    private void updateHealthbar()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth/10;; //update's the health bar to show the player's current health
    }
}
