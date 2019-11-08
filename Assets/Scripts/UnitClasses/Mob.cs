// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

using System.Collections;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField]
    private UnitSettings settings;

    [SerializeField]
    private GameObject healthRemaining;

    private int _currentLifetime;   // When _currentLifetime == 0, the healthBar will disappear

    // Lifetime countdown
    public IEnumerator StartCountdown()
    {
        while (this._currentLifetime > 0)
        {
            yield return new WaitForSeconds(1);
            this._currentLifetime--;
        }
    }

    void Awake()
    {       // If there is no UnitSettings assigned, try to find them. If there are still none, throw an error
        if (!settings)
        {
            Debug.LogError("ERROR: " + this.gameObject + " does not have UnitSettings!");
        }

        // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
        else
        {
            _currentLifetime = settings.maxLifetime;
        }
    }

    void Start()
    {
        // Start the lifetime countdown
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        Vector3 oldScale = healthRemaining.transform.localScale;
        float value = (4 * settings.maxLifetime) / _currentLifetime;
        Debug.Log(value);
        Vector3 newScale = new Vector3(value, oldScale.y, oldScale.z);
        healthRemaining.transform.localScale = newScale;
    }
}
