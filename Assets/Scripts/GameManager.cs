using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;

public class GameManager : MonoBehaviour
{   
    [SerializeField] private loadBanner banner;
    public FloatingJoystick joystick;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;
    public bool isGameActive;
    public int retryCount = 0;
    public Button continueButton;
    public Button backToMenuButton;
    public Button nextLevelButton;
    public GameObject loadImage, player;
    AudioManager audioManager; 
    public UGS_Analytics uGS_Analytics;

    private void Awake(){
        audioManager = GameObject.FindWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        banner.LoadBanner();
    }

    public void StartGame(/*int difficulty*/)
    {   
        isGameActive = true;
    }
        public void GameOver(){
            gameOverText.gameObject.SetActive(true);
            victoryText.gameObject.SetActive(false);
            isGameActive = false;
            continueButton.gameObject.SetActive(true);
            backToMenuButton.gameObject.SetActive(true);
            loadImage.gameObject.SetActive(false);
        //    audioManager.PlaySFX(audioManager.fail);
            player.SetActive(false);
            joystick.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        public void Victory(){
            uGS_Analytics.LevelCompletedCustomEvent();
            uGS_Analytics.FlushData();

            victoryText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(false);
            isGameActive = false;
        //    continueButton.gameObject.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
            loadImage.gameObject.SetActive(false);
                audioManager.PlaySFX(audioManager.clear);
            joystick.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        public void Retry(){
                audioManager.PlaySFX(audioManager.click);
            Time.timeScale = 1;
            retryCount = retryCount + 1;
            // Debug.Log(retryCount);
            uGS_Analytics.RestartCountCustomEvent(retryCount);
            uGS_Analytics.FlushData();   

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void NextLevel(){
            Time.timeScale = 1;
                audioManager.PlaySFX(audioManager.click);
            SceneController.instance.NextLevel();
        }

        public void StageClear(){
            SceneManager.LoadScene("StageClear");
        }
}

