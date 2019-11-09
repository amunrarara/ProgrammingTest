// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// LifeBarController.cs
// Enemies have a lifetime; LifeBarController controls the barObject to display how much life is remaining for an Enemy

using System;
using System.Linq;
using System.Collections;
using UnityEngine;

public class LifeBarController : ParentBarController
{
    // Lifetime properties
    private int _currentLifetime;   // When _currentLifetime == 0, the lifeBar will disappear
    private int _maxLifetime;       // The max lifetime is used to determine lifePercentate in the Update function

    [SerializeField]
    private Vector3 barOffset;           // 2 units above the mob itself
    private Transform[] childTransforms; // First we get the transforms, then we get the Vector3s
    private Vector3[] mobChildren;       // Used to determine the middle point of the mob, and keep the health bar central to the mob

    // Lifetime countdown
    public IEnumerator StartCountdown()
    {
        while (this._currentLifetime > 0)
        {
            yield return new WaitForSeconds(1);
            DepleteLifeBar();
            this._currentLifetime--;
        }
    }

    void Awake()
    { 
        // If there are UnitSettings, initalize this Unit's variables with UnitSettings values
        if (settings)
        {
            // Initialize lifetime properties
            _maxLifetime = settings.maxLifetime;
            _currentLifetime = _maxLifetime;
            previousValue = _currentLifetime;
        }

        childTransforms = new Transform[6];
        mobChildren = new Vector3[6];
    }

    void Start()
    {
        // Start the lifetime countdown
        StartCoroutine(StartCountdown());

        // Receive the Transforms of every Enemy child, then populate mobChildren with their V3s
        childTransforms = transform.Cast<Transform>().Where(c => c.gameObject.tag == "Enemy").ToArray();
        for (int i = 0; i < childTransforms.Length; i++) {
            mobChildren[i] = childTransforms[i].position;
        }
    }

    void LateUpdate()
    {
        // There are MUCH better ways of doing this. I'm goin' down n' dirty here to get a working model up n' running
        // Clear the mobChildren array, then repopulate it with new positions
        Array.Clear(mobChildren, 0, mobChildren.Length);

        // Receive the Transforms of every Enemy child, then populate mobChildren with their V3s
        childTransforms = transform.Cast<Transform>().Where(c => c.gameObject.tag == "Enemy").ToArray();
        for (int i = 0; i < childTransforms.Length; i++)
        {
            mobChildren[i] = childTransforms[i].position;
        }

        // Calculate the middle of the mob, then keep the health bar at that middle point
        Vector3 centroid = calculateCentroid(mobChildren);
        GameObject barHierarchy = barObject.transform.parent.gameObject;
        barHierarchy.transform.position = calculateCentroid(mobChildren) + barOffset;
    }

    // Calculate the middlepoint of every Vector3 in a given Vector3[]
    Vector3 calculateCentroid(Vector3[] centerPoints)
    {
        Vector3 centroid = new Vector3(0, 0, 0);
        int numPoints = centerPoints.Length;
        foreach (Vector3 point in centerPoints)
        {
            centroid += point;
        }

        centroid /= numPoints;

        return centroid;
    }

    // Adjusts the barObject scale to simulate the depletion of life
    private void DepleteLifeBar()
    {
        float percentage = _currentLifetime / _maxLifetime;
        barObject.transform.localScale = Vector3.Lerp(fullBarScale, emptyBarScale, percentage);
    }
}
