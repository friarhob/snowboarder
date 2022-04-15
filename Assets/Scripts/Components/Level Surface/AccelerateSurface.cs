using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateSurface : MonoBehaviour
{
    [SerializeField] float baseSpeed;
    [SerializeField] float accelerationMultiplier;
    [SerializeField] float breakMultiplier;

    private SurfaceEffector2D mySurfaceEffector2D;

    private bool canAccelerate;

    void Start()
    {
        EventManager.onGameOver += this.BlockAcceleration;
        EventManager.onStartNewGame += this.AllowAcceleration;

        mySurfaceEffector2D = this.gameObject.GetComponent<SurfaceEffector2D>();

        AllowAcceleration();
    }

    void OnDestroy()
    {
        EventManager.onGameOver -= this.BlockAcceleration;
        EventManager.onStartNewGame -= this.AllowAcceleration;
    }

    void Update()
    {
        float speed = baseSpeed;

        if (canAccelerate)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                speed += speed * (accelerationMultiplier - 1) * Input.GetAxis("Vertical");
            }
            else
            {
                speed += speed * (breakMultiplier - 1) * -Input.GetAxis("Vertical");
            }
        }

        mySurfaceEffector2D.speed = speed;
    }

    private void BlockAcceleration()
    {
        canAccelerate = false;
    }
    private void AllowAcceleration()
    {
        canAccelerate = true;
    }
}
