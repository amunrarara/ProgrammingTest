// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// SpawnController.cs
// This script handles the spawning of enemies at set intervals. Attach to GameController GameObject

using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private Transform player;             // Player location will be used to spawn mob at a random distance from Player
    [SerializeField]
    private float maxDistanceFromPlayer;  // Maximum number of units away an enemy will spawn from Player

    public int mobCounter { get; private set; }             // mobCounter increases by 1 for every mob that is spawned
    public int secondsSinceLastSpawn { get; private set; }  // How many seconds since the last mob was spawned?

    // Lifetime countdown
    public IEnumerator MobCountdown()
    {
        while (this.secondsSinceLastSpawn >= 0)
        {
            yield return new WaitForSeconds(1);
            this.secondsSinceLastSpawn++;
            Debug.Log(secondsSinceLastSpawn);
        }
    }

    void Awake()
    {
        // At the start of the game, _mobCounter will equal 0, then increase by 1 with each spawned mob
        mobCounter = 0;
        // Also, secondsSinceLastSpawn will be 0, increase each second, and be reset to 0 after a mob is spawned
        secondsSinceLastSpawn = 0;
    }

    void Start()
    {
        // Spawn our first Mob
        SpawnMob(mobCounter);
        mobCounter++;
        // Start MobCountdown
        StartCoroutine(MobCountdown());
    }

    void Update()
    {
        // If 20 seconds have passed since the last Spawn, instantiate a new one and reset secondsSinceLastSpawn to 0
        if (secondsSinceLastSpawn >= 20) {
            SpawnMob(mobCounter);
        }
    }

    // A Mob is spawned at a random distance from the Player
    void SpawnMob(int counter) {
        if (counter < 5)
        {
            // Spawn a weak mob
            // Step : Instantiate the Mob parent at a random point near the Player
            Vector3 mobPosition = RandomEnemyPosition(player.transform.position);
            // Generate a Quaternion for rotation
            Quaternion rotation = player.transform.rotation;
            GameObject mob = Instantiate(Resources.Load("Mob_Weak"), mobPosition, rotation) as GameObject;
            // Step : Instantiate a random number of enemies (3-5) at random points near the Player within minDistanceFromPlayer and maxDistanceFromPlayer, as children of the mob boss (heh heh)
            int count = 0;
            int rand = Random.Range(3,5);
            while (count < rand) {
                // Generate a random point near the Mob boss
                Vector3 randPos = RandomEnemyPosition(mobPosition);
                // Instantiate the enemy unit as a child of WeakMob
                GameObject newEnemy = Instantiate(Resources.Load("Enemy_Weak"), randPos, rotation, mob.transform) as GameObject;
                // Increase the counter by 1
                count++;
            }
        }
        else if (counter < 10)
        {
            // Spawn a mid-strength mob
        }
        else {
            // Spawn a strong mob
        }

        // Reset secondsSinceLastSpawn to 0
        secondsSinceLastSpawn = 0;
    }

    Vector3 RandomEnemyPosition(Vector3 target) {
        // Generate a random point near the Player
        float randX = Random.Range(maxDistanceFromPlayer * -1, maxDistanceFromPlayer);
        float randZ = Random.Range(maxDistanceFromPlayer * -1, maxDistanceFromPlayer);
        // If this random number is TOO CLOSE to the Player (within a single unit), make an adjustment
        if (randX > -2 && randX < 2)
        {
            if (randX > -2) { randX = -2; } else if (randX < 2) { randX = 2; }
        }
        if (randZ > -2 && randZ < 2)
        { if (randZ > -2) { randZ = -2; } else if (randZ < 2) { randZ = 2; } }
        // Generate offset from the player position
        Vector3 offset = new Vector3(randX, 0f, randZ);
        // Generate the new enemy's position
        Vector3 randPos = target + offset;

        return randPos;
    }
}
