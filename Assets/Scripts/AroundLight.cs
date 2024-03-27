using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundLight : MonoBehaviour
{
    private bool isInside = false/*, isInsidePolice = false*/;

    // Hàm được gọi khi đối tượng bắt đầu tiếp xúc với Collider.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Common.playerTag)) // Kiểm tra xem va chạm với đối tượng có tag "Player".
        {
            isInside = true;
//            Debug.Log("Đối tượng đã đi vào bên trong Sphere Collider.");
            PlayerController playerControl = other.gameObject.GetComponent<PlayerController>();
            playerControl.ChangeLightObject(gameObject);
            playerControl.ShadowObject.SetActive(true);
            playerControl.FakeShadow.SetActive(true);
            
        }
    //     if (other.CompareTag("Police")) // Kiểm tra xem va chạm với đối tượng có tag "Police".
    //     {
    //         isInsidePolice = true;
    //         PoliceController policeControl = other.gameObject.GetComponent<PoliceController>();
    //         policeControl.ChangeLightObject(gameObject);
    //         policeControl.ShadowObject.SetActive(true);
    //     }
    }

    // Hàm được gọi khi đối tượng thoát ra khỏi Collider.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Common.playerTag)) // Kiểm tra xem va chạm với đối tượng có tag "Player".
        {
            isInside = false;
//            Debug.Log("Đối tượng đã thoát ra khỏi Sphere Collider.");
            PlayerController playerControl = other.gameObject.GetComponent<PlayerController>();
            playerControl.ShadowObject.SetActive(false);
            playerControl.FakeShadow.SetActive(false);
        }

    //     if (other.CompareTag("Police")) // Kiểm tra xem va chạm với đối tượng có tag "Police".
    //     {
    //         isInsidePolice = false;
    //         PoliceController policeControl = other.gameObject.GetComponent<PoliceController>();
    //         policeControl.ShadowObject.SetActive(false);
    //     }
    }

    // Kiểm tra xem đối tượng có nằm bên trong Sphere Collider hay không.
    public bool IsInsideSphere()
    {
        return isInside;
    //    return isInsidePolice; 
    }
}
