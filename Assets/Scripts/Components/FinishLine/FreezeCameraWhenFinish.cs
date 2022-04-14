using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreezeCameraWhenFinish : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform objectToFollow;
    void Start()
    {
        virtualCamera.Follow = objectToFollow;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            virtualCamera.Follow = null;
        }
    }
}
