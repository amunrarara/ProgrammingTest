// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// HealthBarController.cs
// HealthBarController controls the barObject to display how much health is remaining for the Player

using UnityEngine;

public class HealthBarController : ParentBarController
{
    private Player player;

    // Health properties
    private int _currentHealth;
    private int _maxHealth;

    void Awake()
    {
        if (!player)
        {
            player = GetComponent<Player>();
        }
        if (!player)
        { 
            Debug.LogError("ERROR: You haven't assigned a Player to the HealthBarController");
        }

        // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
        if (settings)
        {
            // Initialize health properties
            _maxHealth = settings.maxHealth;
            _currentHealth = _maxHealth;
            previousValue = _currentHealth;
        }
    }

    void LateUpdate()
    {
        _currentHealth = player.currentHealth;
        if (previousValue != _currentHealth)
        {
            DepleteHealthBar();
            previousValue = _currentHealth;
        }
    }

    // Adjusts the barObject scale to simulate the depletion of health
    private void DepleteHealthBar()
    {
        float percentage = _currentHealth / _maxHealth;
        barObject.transform.localScale = Vector3.Lerp(fullBarScale, emptyBarScale, percentage);
    }
}
