// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// UnitSettings.cs
// A ScriptableObject that is attached as a component to every Unit which feeds initial values to that unit's primary variables.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSettings : ScriptableObject
{
    // These variables are READ-ONLY and used ONLY for initialization
    private int _maxHealth;         // Maximum health of this unit
    private int _damage;            // Damage that this unit 
    private int _speed;             // Movement at units per second
    private int _maxLifetime;       // Maximum lifetime (in seconds) of this unit

    public int maxHealth {
        get { return _maxHealth; }
    }         
    public int damage {
        get { return _damage; }
    }          
    public int speed {
        get { return _speed; }
    }           
    public int maxLifetime {
        get { return _maxLifetime; }
    }       


}
