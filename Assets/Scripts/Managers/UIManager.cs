using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] float timeAfterWinning;
    [SerializeField] float timeAfterCrashing;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    void Start()
    {
        EventManager.onStartNewGame += ReloadScene;
        EventManager.onFinishRun += this.FinishGame;
        EventManager.onSnowboarderCrash += this.PlayerCrash;
    }

    void OnDestroy()
    {
        EventManager.onStartNewGame -= ReloadScene;
        EventManager.onFinishRun -= this.FinishGame;
        EventManager.onSnowboarderCrash -= this.PlayerCrash;
    }

    void Update()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(GameManager.Instance.score);
        highScoreText.text = "High Score: " + Mathf.FloorToInt(GameManager.Instance.highestScore);
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

    private void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
