using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float MagicNumber= 1.5f;
    [SerializeField] ParticleSystem FinishEffect;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            FinishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", MagicNumber);
            
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
