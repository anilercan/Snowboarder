using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    public bool crashed=false;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Ground"&&crashed==false){
            crashed=true;
            Invoke("ReloadScene",2.5f);
            crashEffect.Play();
            GetComponent<AudioSource>().Play();
        }
        if (other.tag=="Flag"){
            crashed=true;
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
