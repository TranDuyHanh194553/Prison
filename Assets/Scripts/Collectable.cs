using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    AudioManager audioManager;

    public CollectableCount collectableCount;
    private void Awake(){
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    total++;
    }

//    void Awake() => total++;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Player")){
                audioManager.PlaySFX(audioManager.getKey);
            OnCollected?.Invoke();
            collectableCount.CollectKey();
        //    Destroy(gameObject);
        }
    }
}
