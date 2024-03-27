using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject loadImage;
    private void Awake(){
            audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        StartCoroutine(Blur());
    }
    public void PlayGame(){
            audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadSceneAsync(0);  
    }

        IEnumerator Blur(){
            yield return new WaitForSeconds(0.5f);
            loadImage.gameObject.SetActive(false);
        }

  
}
