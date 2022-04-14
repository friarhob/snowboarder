using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] AudioSource crashEffect;
    [SerializeField] AudioSource endingEffect;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    void Start()
    {
        EventManager.onSnowboarderCrash += this.PlayCrashEffect;
        EventManager.onFinishRun += this.PlayEndingEffect;
    }

    void OnDestroy()
    {
        EventManager.onSnowboarderCrash -= this.PlayCrashEffect;
        EventManager.onFinishRun -= this.PlayEndingEffect;
    }

    private void PlayCrashEffect()
    {
        this.crashEffect.Play();
    }

    private void PlayEndingEffect()
    {
        this.endingEffect.Play();
    }
}