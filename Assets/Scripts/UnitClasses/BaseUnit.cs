// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// BaseUnit.cs
// The superparent of all other unit types in the project

using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    // Unit Variables
    protected int _maxHealth;         // Maximum health of this unit
    protected int _currentHealth;     // When _currentHealth == 0, the unit is destroyed
    protected int _damage;            // Damage that this unit 
    protected int _maxLifetime;       // Maximum lifetime (in seconds) of this unit
    protected int _currentLifetime;   // When _currentLifetime == 0, the unit is destroyed

    public int damage
    {
        get { return _damage; }
    }

    [SerializeField]
    protected UnitSettings _settings; // UnitSettings will feed initial values to this Unit's variables

    public UnitSettings settings { get { return _settings; } }

    void Awake()
    {
        // If there is no UnitSettings assigned, try to find them. If there are still none, throw an error
        if (!_settings)
        {
            Debug.LogError("ERROR: " + this.gameObject + " does not have UnitSettings!");
        }

        // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
        else
        {
            this._maxHealth = settings.maxHealth;
            this._currentHealth = this._maxHealth;
            this._damage = settings.damage;
            this._maxLifetime = settings.maxLifetime;
            this._currentLifetime = this._maxLifetime;
        }
    }

    // Called when this Unit has been damaged by another Unit
    public virtual void TakeDamage(int damage) {
        // If this Unit's current health is greater than the damage it's receiving, then subtract that damage from currentHealth...
        if (this._currentHealth > damage)
        {
            this._currentHealth -= damage;
        }
        // ... otherwise, destroy this Unit
        else {
            Die();
        }
    }

    // Called when: a) Damage dealt to this unit equals or exceeds its currentHealth, or b) when currentLifetime <= 0
    public virtual void Die() {
        Destroy(this.gameObject);
    }
}
