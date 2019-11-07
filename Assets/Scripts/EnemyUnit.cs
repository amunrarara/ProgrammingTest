// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : BaseUnit
{
    // Lifetime countdown
    public IEnumerator StartCountdown() {
        while (this._currentLifetime > 0) {
            yield return new WaitForSeconds(1);
            this._currentLifetime--;
        }
    }

    private void Start()
    {
        // Start the lifetime countdown
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {
        // If currentLifetime reaches 0 (or less, for some reason), then destroy this Unit
        if (this._currentLifetime <= 0)
        {
            Die();
        }
    }

    // Called any time a collision occurs
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(collision.gameObject.GetComponent<UnitSettings>().damage);
        }
    }
}
