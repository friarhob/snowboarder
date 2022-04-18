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

    public delegate void BackwardFlip();
    public static event BackwardFlip onBackwardFlip;

    public delegate void ForwardFlip();
    public static event ForwardFlip onForwardFlip;

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
        Debug.Log("Invoking Game Over");
        onGameOver?.Invoke();
    }

    public void newGame()
    {
        Debug.Log("Invoking New Game");
        onStartNewGame?.Invoke();
    }

    public void backwardFlip()
    {
        onBackwardFlip?.Invoke();
    }

    public void forwardFlip()
    {
        onForwardFlip?.Invoke();
    }
}
