using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    AudioManager audioManager;
    public GameObject instructionPanel, exitPanel, title, playButton;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    public void PlayGame(){
        Time.timeScale = 1;        
            audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadSceneAsync(1);  
    }

    public void InstrutionPanel(){
            audioManager.PlaySFX(audioManager.click);   
        instructionPanel.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
    }

    public void ExitInstrution(){
            audioManager.PlaySFX(audioManager.click);   
        instructionPanel.gameObject.SetActive(false);
        title.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);

    }

    public void Options(){
            audioManager.PlaySFX(audioManager.click);
    }

    public void QuitGame(){
            audioManager.PlaySFX(audioManager.click);
        Application.Quit();
    }
}
