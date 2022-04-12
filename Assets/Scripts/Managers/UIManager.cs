using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    void Start()
    {
        EventManager.onStartNewGame += ReloadScene;
    }

    void OnDestroy()
    {
        EventManager.onStartNewGame -= ReloadScene;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
