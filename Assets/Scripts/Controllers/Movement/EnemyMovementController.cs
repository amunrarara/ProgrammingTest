// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// EnemyMovementController.cs
// While an Enemy is alive, it is constantly pursuing the Player. To prevent mobbing, once the Enemy makes contact with the Player, it is stopped for 1 second.

using UnityEngine;

public class EnemyMovementController : ParentMovementController
{
    [SerializeField]
    private Transform player;

    void Start()
    {
        if (!player) {
            // This is a messy way to do it. I will refactor a cleaner way of referencing the Player at a later time.
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (!player) {
                Debug.LogError("ERROR: You must assign the Player object to this Unit!");
            }
        }
    }

    void Update()
    {
        // Every update, set the NavMeshAgent's destination to the Player 
        if (agent && player) {
            agent.SetDestination(player.position);
        }
    }
}
