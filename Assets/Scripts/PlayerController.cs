using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    // [SerializeField] private Animator m_animator = null;
    [SerializeField] private GameObject playerKey;
    [SerializeField] private int totalKey = 4;
    public GameObject ShadowObject, FakeShadow;
    private GameManager gameManager;
    [SerializeField] private GameObject leftDoor, rightDoor, finalPath/*, stageGate*/;
    [SerializeField] private bool hasKey = false;
    private int keyCount = 0;
//    AudioManager audioManager;
    private void Awake()
    {
        // if (!m_animator) { gameObject.GetComponent<Animator>(); }
        
//        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ChangeLightObject(GameObject light)
    {
        ShadowScale aroundLight = ShadowObject.GetComponent<ShadowScale>();
        aroundLight.ChangeLight(light);
    }

    void OnTriggerEnter(Collider other){

        if (keyCount == totalKey && hasKey && other.CompareTag("FinalPath")){

            leftDoor.transform.Rotate(Vector3.up, 90.0f);
            rightDoor.transform.Rotate(Vector3.up, -90.0f); 
            Debug.Log("Clear!");
            Destroy(finalPath.gameObject);
        
            // m_animator.SetTrigger("Wave");
            hasKey = false;

            // stageGate.SetActive(true);
            gameManager.Victory();
                
        }


        if (other.CompareTag("Collectable")){
            hasKey = true;
            keyCount = keyCount + 1;
            Debug.Log(keyCount + " key collected");

            playerKey.SetActive(true);
        }
    }

    public bool HasKey()
    {
        return hasKey;
    }
    
}
