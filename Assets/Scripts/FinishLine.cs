using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] CrashDetector crashDetector;
    void Start(){
        crashDetector=FindObjectOfType<CrashDetector>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Player"){
            Invoke("ReloadScene",2.5f);
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
