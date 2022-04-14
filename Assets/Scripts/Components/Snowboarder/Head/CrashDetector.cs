using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeToReload;
    [SerializeField] ParticleSystem crashEffect;
    private bool alreadyCrashed;

    void Start()
    {
        EventManager.onSnowboarderCrash += this.Bleed;
        EventManager.onStartNewGame += this.ResetNewGame;

        ResetNewGame();
    }

    void OnDestroy()
    {
        EventManager.onSnowboarderCrash -= this.Bleed;
        EventManager.onStartNewGame -= this.ResetNewGame;
    }

    private void Bleed()
    {
        FindObjectOfType<PlayerController>().Crash();
        crashEffect.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!alreadyCrashed && other.tag == "Ground")
        {
            EventManager.Instance.snowboarderCrash();
            alreadyCrashed = true;
        }
    }

    void ResetNewGame()
    {
        alreadyCrashed = false;
    }
}
