// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// ParentMovementController.cs
// Sets base properties and initializations for all inheriting MovementController classes

using UnityEngine;
using UnityEngine.AI;

public class ParentMovementController : MonoBehaviour
{

    protected UnitSettings settings;  // UnitSettings will feed initial values to this Unit's variables
    protected NavMeshAgent agent;       // Unit's NavMeshAgent for Navigation system
    protected int _speed;             // Speed property is used to set NavMeshUnit's speed

    void Awake()
    {
        // If there is no UnitSettings assigned, try to find them. If there are still none, throw an error
        if (!settings)
        {
            settings = this.gameObject.GetComponent<BaseUnit>().settings;
            if (!settings) {
                Debug.LogError("ERROR: This Unit does not have UnitSettings!");
            }
            else    // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
            {
                this._speed = settings.speed;
            }
        }

        if (!agent)
        {
            // Normally, I would implement error handling for the following property assignment. For this test, I'm doin' it dirty!
            agent = this.gameObject.GetComponent<NavMeshAgent>();

            if (!agent)
            {
                Debug.LogError("ERROR: This Unit does not have a NavMeshUnit!");
            }
        }

        // If there's UnitSettings and a NavMeshAgent, initialize the NavMeshAgent's speed property
        if (agent && settings) {
            agent.speed = this._speed;
        }

    }
}
