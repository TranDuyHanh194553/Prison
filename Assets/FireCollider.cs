using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{   
    [SerializeField] private GameObject hiddenFlame;
    private GameManager gameManager;
    AudioManager audioManager;

     private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Bonfire")){
            Debug.Log("Burned!");
            hiddenFlame.gameObject.SetActive(true);
            gameObject.SetActive(false);
            	audioManager.PlaySFX(audioManager.sus);
            gameManager.GameOver();
            Time.timeScale = 1;
        }
    }   
}
