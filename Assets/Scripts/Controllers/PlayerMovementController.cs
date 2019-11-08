// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// PlayerMovementController.cs
// When the player right-clicks on a walkable area, the Player NavMeshAgent will set that point as the destination

using UnityEngine;

public class PlayerMovementController : ParentMovementController
{
    [SerializeField]
    private LayerMask walkableArea;

    void Update()
    {
        if (agent) {
            // When the player right clicks, cast a ray from that screen position into the game world
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // If the ray hits a walkableArea within 250 units, then set that as the Player's destination
                if (Physics.Raycast(ray, out hit, 250, walkableArea))
                {
                    this.agent.SetDestination(hit.point);
                }
            }
        }

    }
}
