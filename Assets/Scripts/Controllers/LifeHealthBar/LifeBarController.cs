// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// LifeBarController.cs
// Enemies have a lifetime; LifeBarController controls the barObject to display how much life is remaining for an Enemy

using UnityEngine;

public class LifeBarController : ParentBarController
{
    // Lifetime properties
    private float _currentLifetime;   // When _currentLifetime == 0, the lifeBar will disappear
    private float _maxLifetime;       // The max lifetime is used to determine lifePercentate in the Update function

    private EnemyUnit enemy;

    void Awake()
    {
        // If there is no enemy assigned, try to find them. If there are still none, throw an error
        if (!enemy)
        {
            // Later: use error handling before attempting assignment
            enemy = transform.parent.GetComponent<EnemyUnit>();

            if (!enemy)
            {
                Debug.LogError("ERROR: Cannot locate Parent unit!");
            }
        }

        // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
        if (enemy)
        {
            // Initialize lifetime properties
            _maxLifetime = enemy.maxLifetime;
            _currentLifetime = _maxLifetime;
        }
    }

    void LateUpdate()
    {
        // Read the Enemy's currentLifetime, then update the LifeBar to reflect that value
        _currentLifetime = enemy.currentLifetime;
        DepleteLifeBar();
    }

    // Adjusts the barObject scale to simulate the depletion of life
    private void DepleteLifeBar()
    {
        float perc =  (_currentLifetime / _maxLifetime) * 4;
        barObject.transform.localScale = new Vector3(perc, 1.2f, 1.2f);
    }
}
