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
}
