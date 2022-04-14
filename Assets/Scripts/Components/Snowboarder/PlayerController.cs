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
        EventManager.onSnowboarderCrash += this.StopMoving;

        canMove = true;
        playerRigidbody = GetComponent<Rigidbody2D>();
        levelSurface = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnDestroy()
    {
        EventManager.onSnowboarderCrash -= this.StopMoving;
    }

    void Update()
    {
        if (canMove)
        {
            playerRigidbody.AddTorque(-torqueAmount * Input.GetAxis("Horizontal"));
        }
    }

    private void StopMoving()
    {
        canMove = false;
    }
}
