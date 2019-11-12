// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// ParentBarController.cs
// Player has health; Enemies have a lifetime; LifeBar shows how much health/life is remaining for a Player/Enemy

using System.Collections;
using UnityEngine;

public abstract class ParentBarController : MonoBehaviour
{
    [SerializeField]
    protected GameObject barObject;

    // These values are Lerp'd between to give the effect of a life bar depleting. In the Start function, these values are determined by the instantiated Prefab's initial scale
    protected Vector3 fullBarScale;
    protected Vector3 emptyBarScale;

    void Awake()
    {

        if (!barObject) {
            Debug.LogError("ERROR: " + this.gameObject + " does not have a barObject object associated with it!");
        }
    }   

    void Start()
    {
        // Initialize the life bar's size vectors
        fullBarScale = new Vector3(4, 1.2f, 1.2f);
        emptyBarScale = new Vector3(0, 1.2f, 1.2f);
        barObject.transform.localScale = fullBarScale;
    }


}
