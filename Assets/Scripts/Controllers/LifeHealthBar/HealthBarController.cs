// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// HealthBarController.cs
// HealthBarController controls the barObject to display how much health is remaining for the Player

using UnityEngine;

public class HealthBarController : ParentBarController
{
    // Health properties
    private float _currentHealth;
    private float _maxHealth;

    private Player player;

    void Awake()
    {
        // If there is no player assigned, try to find them. If there are still none, throw an error
        if (!player)
        {
            // Later: use error handling before attempting assignment
            player = transform.parent.GetComponent<Player>();

            if (!player)
            {
                Debug.LogError("ERROR: Cannot locate Parent unit!");
            }
        }
    }

    void Start()
    {
        // If there is a player, initalize this Unit's variables with UnitSettings values
        if (player)
        {
            // Initialize health properties
            _maxHealth = player.maxHealth;
            _currentHealth = _maxHealth;
            Debug.Log(_maxHealth);
        }
    }

    void LateUpdate()
    {
        // Read the Player's currentHealth, then update the healthBar to reflect that value
        _currentHealth = player.currentHealth;
        DepleteHealthBar();
    }

    // Adjusts the barObject scale to simulate the depletion of health
    private void DepleteHealthBar()
    {
        float perc = (_currentHealth / _maxHealth) * 4;
        barObject.transform.localScale = new Vector3(perc, 1.2f, 1.2f);
    }
}
