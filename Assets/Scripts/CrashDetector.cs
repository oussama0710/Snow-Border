using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float MagicNumber= 1.5f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip CrashSFX ;
    bool DBD = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !DBD)
        {
            DBD = true;
            FindObjectOfType<PlayerController>().DisableControls();
            CrashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX);
            Invoke("ReloadScene", MagicNumber);
            
        }
        
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
