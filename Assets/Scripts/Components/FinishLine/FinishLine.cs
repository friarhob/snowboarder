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
        EventManager.onFinishRun += this.PlaySound;
    }

    void OnDestroy()
    {
        EventManager.onFinishRun -= this.GenerateSparks;
        EventManager.onFinishRun -= this.PlaySound;
    }

    private void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    private void GenerateSparks()
    {
        finishEffect.Play();

        Invoke("ReloadScene", timeToReload);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            EventManager.Instance.finishRun();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

}

