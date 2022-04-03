using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float boostSpeed;
    [SerializeField] float normalSpeed;
    private bool canMove;

    private Rigidbody2D playerRigidbody;
    private SurfaceEffector2D levelSurface;

    void Start()
    {
        canMove = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        levelSurface = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotateSnowboarder();
            BoostSnowboarderSpeed();
        }
    }

    public void Crash()
    {
        canMove = false;
    }

    private void BoostSnowboarderSpeed()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            levelSurface.speed = boostSpeed;
        }
        else
        {
            levelSurface.speed = normalSpeed;
        }
    }

    private void RotateSnowboarder()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRigidbody.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRigidbody.AddTorque(-torqueAmount);
        }
    }
}
