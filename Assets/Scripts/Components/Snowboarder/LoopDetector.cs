using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDetector : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    void Start()
    {
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (myRigidbody2D.rotation > 270)
        {
            EventManager.Instance.backwardFlip();
            myRigidbody2D.rotation -= 360;
        }

        if (myRigidbody2D.rotation < -270)
        {
            EventManager.Instance.forwardFlip();
            myRigidbody2D.rotation += 360;
        }
    }
}
