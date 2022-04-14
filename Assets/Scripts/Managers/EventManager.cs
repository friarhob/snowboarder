using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public delegate void FinishRun();
    public static event FinishRun onFinishRun;

    public delegate void SnowboarderCrash();
    public static event SnowboarderCrash onSnowboarderCrash;

    public delegate void GameOver();
    public static event GameOver onGameOver;

    public delegate void StartNewGame();
    public static event StartNewGame onStartNewGame;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    public void finishRun()
    {
        onFinishRun?.Invoke();
    }

    public void snowboarderCrash()
    {
        onSnowboarderCrash?.Invoke();
    }

    public void gameOver()
    {
        onGameOver?.Invoke();
    }

    public void resetGame(float timeToReload)
    {
        gameOver();
        Invoke("newGame", timeToReload);
    }

    public void newGame()
    {
        onStartNewGame?.Invoke();
    }
}
