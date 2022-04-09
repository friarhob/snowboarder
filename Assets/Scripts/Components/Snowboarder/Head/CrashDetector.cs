using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float timeToReload;
    [SerializeField] ParticleSystem crashEffect;
    private bool alreadyCrashed;

    void Start()
    {
        alreadyCrashed = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(!alreadyCrashed && other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().Crash();
            alreadyCrashed = true;
            crashEffect.Play();
            GetComponent<AudioSource>().Play();
            
            Invoke("ReloadScene", timeToReload);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
