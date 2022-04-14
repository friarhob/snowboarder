using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] float timeAfterWinning;
    [SerializeField] float timeAfterCrashing;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.onFinishRun += this.FinishGame;
        EventManager.onSnowboarderCrash += this.PlayerCrash;
    }

    void OnDestroy()
    {
        EventManager.onFinishRun -= this.FinishGame;
        EventManager.onSnowboarderCrash -= this.PlayerCrash;
    }

    void PlayerCrash()
    {
        EventManager.Instance.gameOver();
        Invoke("CallNewGame", timeAfterCrashing);
    }

    void FinishGame()
    {
        EventManager.Instance.gameOver();
        Invoke("CallNewGame", timeAfterWinning);
    }

    private void CallNewGame()
    {
        EventManager.Instance.newGame();
    }
}
