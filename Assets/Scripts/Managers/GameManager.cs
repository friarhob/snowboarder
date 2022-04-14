using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = Instance ? Instance : this;
    }

    void Start()
    {
        EventManager.onBackwardFlip += this.BackwardFlip;
        EventManager.onForwardFlip += this.ForwardFlip;
    }

    void OnDestroy()
    {

        EventManager.onBackwardFlip -= this.BackwardFlip;
        EventManager.onForwardFlip -= this.ForwardFlip;
    }

    private void ForwardFlip()
    {
        Debug.Log("Forward Flip!");
    }

    private void BackwardFlip()
    {
        Debug.Log("Backward Flip!");
    }

}
