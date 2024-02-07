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
    [SerializeField]
    bool UpDownMovementEnabled;

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
        //cos tam

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        
        if (UpDownMovementEnabled)
        {
            // góra i dó³
            transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //lewo i prawo
        playerBody.transform.Rotate(new Vector3(0, mouseX, 0));
        
    }
        
}
