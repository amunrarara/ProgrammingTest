// Created by Acea Spades Black Games (https://aceaspadesgames.com/), November 2019
// This work is licensed under a Creative Commons Attribution 4.0 International License (https://creativecommons.org/licenses/by/4.0/)

// You are free to copy, share, alter, adapt, and distribute this project, but are required by law to give appropriate credit to Acea Spades Black Games (https://aceaspadesgames.com/), provide a link to this license (https://creativecommons.org/licenses/by/4.0/), and indicate if any changes were made. 

// Thank you dearly! - Warm regards, Acea Spades

// GameController.cs
// This script keeps track of the gamestate (such as time played) and other high-level functionality

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Timer properties
    public Text gameTimerText;
    private float gameTime;

    void Start()
    {
        // Set the gameTime to 0 at the start of the game
        this.gameTime = 0f;
    }

    void Update()
    {
        // Progress the timer by time spent in the game, then update the UICanvas Text with the visually-formatted time
        this.gameTime += Time.deltaTime;
        gameTimerText.text = SetDisplayTime(gameTime);
    }

    // Receives a float representing time spent in the game, then formats it into a string styled as minutes:seconds (MM:SS)
    private string SetDisplayTime(float time) {
        int seconds = (int)(time % 60);
        int minutes = (int)(time / 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        return timerString;
    }
}
