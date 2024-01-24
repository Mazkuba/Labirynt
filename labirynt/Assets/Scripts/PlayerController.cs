using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    CharacterController characterController;
    Rigidbody rb;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal"),
               z = Input.GetAxis("Vertical");

        //float y = transform.position.y;
        Vector3 move = transform.right * x + transform.up * rb.velocity.y + transform.forward * z;
        characterController.Move(move * speed);
    }
}
