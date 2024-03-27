using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveForCollectable : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
