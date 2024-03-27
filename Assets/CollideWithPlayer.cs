using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    [SerializeField] GameObject leftDoor, rightDoor;
    [SerializeField] GameObject playerKey;
    AudioManager audioManager;
    private void Awake(){
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("PlayerKey")){

            leftDoor.transform.Rotate(Vector3.up, 90.0f);
            rightDoor.transform.Rotate(Vector3.up, -90.0f); 
                audioManager.PlaySFX(audioManager.doorOpen);
            playerKey.SetActive(false);
            Debug.Log("Open!");
            Destroy(gameObject);
        }

    }
}
