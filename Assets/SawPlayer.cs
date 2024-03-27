using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPlayer : MonoBehaviour
{
    private GameManager gameManager;
	AudioManager audioManager;
	[SerializeField] private GameObject deadByCamera;
    public UGS_Analytics uGS_Analytics;
	public string deadBecauseOf;

    private void Awake(){
	audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}
    void Start() {
	    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
    void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Player")){
                // audioManager.PlaySFX(audioManager.flashLight);
                audioManager.PlaySFX(audioManager.sus);
            Debug.Log("Camera found player!");
            gameManager.GameOver();
            deadByCamera.gameObject.SetActive(true);
            uGS_Analytics.DeadReasonCustomEvent(deadBecauseOf);
        }
    }
}
