using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float timeToReload;
    [SerializeField] ParticleSystem finishEffect;

    void Start()
    {
        EventManager.onFinishRun += this.GenerateSparks;
    }

    void OnDestroy()
    {
        EventManager.onFinishRun -= this.GenerateSparks;
    }


    private void GenerateSparks()
    {
        finishEffect.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EventManager.Instance.finishRun();
        }
    }
}

