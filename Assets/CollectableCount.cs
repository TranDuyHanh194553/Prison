using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCount : MonoBehaviour
{
   TMPro.TMP_Text text;
   int keyCount;
   public GameObject[] keys;  // Mảng chứa các chiếc chìa khóa
   private int collectedKeys = 0;  // Số lượng chìa khóa đã thu thập
   void Awake(){
        text = GetComponent<TMPro.TMP_Text>();
   }

   void Start() => UpdateCount();
   void OnEnable() => Collectable.OnCollected += OnCollectableCollected;
   void OnDisable() =>  Collectable.OnCollected -= OnCollectableCollected;

   void OnCollectableCollected(){
    keyCount++;
    UpdateCount();
   }

   void UpdateCount(){
    text.text = "      " /*+ $"{keyCount}"*/;
   }
   public void CollectKey()
    {
        if (collectedKeys < keys.Length)
        {
            keys[collectedKeys].gameObject.SetActive(false); // Ẩn chiếc chìa khóa đã thu thập
            collectedKeys++;
        }
    }
}   
