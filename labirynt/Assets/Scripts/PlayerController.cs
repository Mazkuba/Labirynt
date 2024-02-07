using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    CharacterController characterController;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Transform groundChecker;
    [SerializeField]
    Text pointsUI;
    [SerializeField]
    private int points;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
      
    }
    private void Update()
    {
        PlayerMove();
        ApplyPhysics();
        ResetPlayer();
        AddPointsUI();
    }

    void ResetPlayer()
    {
        if(transform.position.y <= -5f)
        {
            Debug.LogError("PLAYER IS OUT OF THE MAP");
        }
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal"),
               z = Input.GetAxis("Vertical");

        //float y = transform.position.y;
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit hit;
        if(Physics.Raycast(groundChecker.position, Vector3.down, out hit, 0.4f, groundLayer))
        {
            switch (hit.transform.tag)
            {
                case "Low":
                    speed = 1;
                    break;
                case "High":
                    speed = 9;
                    break;
                default:
                    speed = 5;
                    break;

            }
        }
      
    }

    void ApplyPhysics()
    {
        characterController.Move(Physics.gravity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "Pickup")
        {
            hit.collider.GetComponent<Pickup>().Picked();
            //Add point
            points++;

        }
    }

    void AddPointsUI()
    {
        pointsUI.text = $"Points: {points}";
    }
}
