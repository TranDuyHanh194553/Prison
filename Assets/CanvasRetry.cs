using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasRetry : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake(){
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void PlayGame(){
        Time.timeScale = 1;    
            audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadSceneAsync(0);  
    }
}
