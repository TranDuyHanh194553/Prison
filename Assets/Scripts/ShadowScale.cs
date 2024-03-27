using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScale : MonoBehaviour
{
//    public Transform dist;
    public GameObject obj;
    void Start()
    {
        
    }

    public void ChangeLight(GameObject newObject)
    {
        obj = newObject;
    }

    void Update()
    {   

        float dist = Vector3.Distance(obj.transform.position, transform.position);
        Vector3 scl = transform.localScale;
        scl.y = dist / 9;
        transform.localScale = scl;
        transform.LookAt(obj.transform);
        Vector3 rot = transform.eulerAngles;
        rot.x = 270;
        transform.eulerAngles = rot;
        
    }
}
