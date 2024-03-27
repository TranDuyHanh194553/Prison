using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;
    public void Awake(){
        if(instance == null){
            instance = this;
//            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    public void NextLevel(){
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel(){
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadSceneAsync(sceneName);
    }
}
