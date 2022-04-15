using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    private bool canMove;

    private Rigidbody2D myRigidbody;

    void Start()
    {
        EventManager.onSnowboarderCrash += this.StopMoving;

        canMove = true;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnDestroy()
    {
        EventManager.onSnowboarderCrash -= this.StopMoving;
    }

    void Update()
    {
        if (canMove)
        {
            myRigidbody.AddTorque(-torqueAmount * Input.GetAxis("Horizontal"));
        }
    }

    private void StopMoving()
    {
        canMove = false;
    }
}
