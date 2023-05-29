using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ch : MonoBehaviour
{
    public CharacterController controller;
    public LayerMask groundMask;
    public Transform GroundCheck;
    public float speed = 10f;
    public float gravity = 9.8f;
    public float jumpHaigt = 3f;
    public float groundDistance = 0.4f;
    private Vector3 velocity;


    bool isGrounded;

    public int jumpHeight = 8;
    void Start()
    {
  

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHaigt * gravity);
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey("c"))
        {
            controller.height = 0.75f;
        }
        else
        {
            controller.height = 1.7f;
        }
    }
}
