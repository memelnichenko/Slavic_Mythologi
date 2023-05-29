using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement1 : MonoBehaviour
{
    public float speed = 10f;

    public CharacterController characterController;

    Vector3 move;

    Vector3 velocity;

    public float gravity = -22f;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHight = 3f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (characterController.isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHight * -2 * gravity);
            }

        }

    }



}




