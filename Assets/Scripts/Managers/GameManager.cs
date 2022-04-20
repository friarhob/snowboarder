using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float score { get; private set; }
    public float highestScore { get; private set; }
    private bool gameRunning;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    void Start()
    {
        EventManager.onBackwardFlip += this.BackwardFlip;
        EventManager.onForwardFlip += this.ForwardFlip;
        EventManager.onGameOver += this.StopGame;
        EventManager.onStartNewGame += this.StartGame;

        Debug.Log("Getting High Score");
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highestScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            highestScore = 0;
        }
        Debug.Log("High Score Got " + highestScore);

        StartGame();
    }

    void OnDestroy()
    {
        EventManager.onBackwardFlip -= this.BackwardFlip;
        EventManager.onForwardFlip -= this.ForwardFlip;
        EventManager.onGameOver -= this.StopGame;
        EventManager.onStartNewGame -= this.StartGame;
    }

    void Update()
    {
        if (gameRunning)
        {
            score += 37 * Time.deltaTime;
        }
    }

    private void ForwardFlip()
    {
        if (gameRunning)
        {
            score += 1000;
        }
    }

    private void BackwardFlip()
    {
        if (gameRunning)
        {
            score += 500;
        }
    }

    private void StopGame()
    {
        gameRunning = false;

        if (score > highestScore)
        {
            highestScore = score;

            PlayerPrefs.SetFloat("HighScore", highestScore);
            PlayerPrefs.Save();
        }
    }

    private void StartGame()
    {
        score = 0;
        gameRunning = true;
    }
}
