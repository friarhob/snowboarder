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

        alreadyCrashed = false;
    }

    void OnDestroy()
    {
        EventManager.onSnowboarderCrash -= this.Bleed;
    }

    private void Bleed()
    {
        FindObjectOfType<PlayerController>().Crash();
        crashEffect.Play();
        GetComponent<AudioSource>().Play();

        EventManager.Instance.resetGame(timeToReload);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!alreadyCrashed && other.tag == "Ground")
        {
            EventManager.Instance.snowboarderCrash();
            alreadyCrashed = true;
        }
    }
}
