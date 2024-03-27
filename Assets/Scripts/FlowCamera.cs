using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public float rotationSpeed;

    public GameObject player;
    [SerializeField]
    private float cameraX, cameraY, cameraZ;
    void Update()
    {
        transform.position = player.transform.position + new Vector3(cameraX, cameraY, cameraZ);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
