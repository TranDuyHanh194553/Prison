using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnScreen : MonoBehaviour
{
   TMPro.TMP_Text text;
   [SerializeField] private int level;

   void Awake(){
        text = GetComponent<TMPro.TMP_Text>();
   }
   void Start(){
    text.text = "Level " + level;
   }
}   
