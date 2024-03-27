using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public GameObject ShadowObject;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLightObject(GameObject light)
    {
        ShadowScale aroundLight = ShadowObject.GetComponent<ShadowScale>();
        aroundLight.ChangeLight(light);
    }
    
}
