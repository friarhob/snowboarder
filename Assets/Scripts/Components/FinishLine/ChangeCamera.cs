using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] Camera finishCamera;
    [SerializeField] Camera mainCamera;
    void Start()
    {
        finishCamera.depth = -5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            finishCamera.transform.position = mainCamera.transform.position;
            finishCamera.transform.rotation = mainCamera.transform.rotation;

            finishCamera.depth = 0;
        }
    }
}
