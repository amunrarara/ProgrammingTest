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

    // A mob of Enemies are spawned at a random distance from the Player
    void SpawnMob(int counter) {

        switch (counter)
        {
            case int n when (counter < 5):
                int count1 = 0;
                int rand1 = Random.Range(3, 5);
                while (count1 < rand1)
                {
                    // Generate a random point near the Mob boss
                    Vector3 randPos = RandomEnemyPosition(player.transform.position);
                    // Generate a Quaternion for rotation
                    Quaternion rotation = player.transform.rotation;
                    // Instantiate the enemy unit as a child of WeakMob
                    GameObject newEnemy = Instantiate(Resources.Load("Enemy_Weak"), randPos, rotation) as GameObject;
                    // Increase the counter by 1
                    count1++;
                }
                break;

            case int n when (counter < 10):
                {
                    int count2 = 0;
                    int rand2 = Random.Range(3, 5);
                    while (count2 < rand2)
                    {
                        // Generate a random point near the Mob boss
                        Vector3 randPos = RandomEnemyPosition(player.transform.position);
                        // Generate a Quaternion for rotation
                        Quaternion rotation = player.transform.rotation;
                        // Instantiate the enemy unit as a child of WeakMob
                        GameObject newEnemy = Instantiate(Resources.Load("Enemy_Mid"), randPos, rotation) as GameObject;
                        // Increase the counter by 1
                        count2++;
                    }
                    break;
                }

            case int n when (counter >= 10):
                {
                    int count2 = 0;
                    int rand2 = Random.Range(3, 5);
                    while (count2 < rand2)
                    {
                        // Generate a random point near the Mob boss
                        Vector3 randPos = RandomEnemyPosition(player.transform.position);
                        // Generate a Quaternion for rotation
                        Quaternion rotation = player.transform.rotation;
                        // Instantiate the enemy unit as a child of WeakMob
                        GameObject newEnemy = Instantiate(Resources.Load("Enemy_Strong"), randPos, rotation) as GameObject;
                        // Increase the counter by 1
                        count2++;
                    }
                    break;
                }
        }
        
        // After the mob is spawned, set secondsSinceLastSpawn to 0
        secondsSinceLastSpawn = 0;
        mobCounter++;
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
