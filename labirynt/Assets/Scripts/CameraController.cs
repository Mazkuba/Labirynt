using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity;
    float xRot = 0f;
    [SerializeField]
    Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        //gora dol
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerBody.transform.Rotate(new Vector3(0, mouseX, 0));
        
    }
        
}
