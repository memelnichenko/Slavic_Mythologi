using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
        private CharacterController cc;
        public float gravity;
        public float jumpForce;
        public float speed;
        private float jspeed = 0;

         void Awake()
        {
            cc = GetComponent<CharacterController>();

        }

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (cc.isGrounded)
        {
           
            jspeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jspeed = jumpForce;
            }
        }
        jspeed += gravity * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(horizontal * speed * Time.deltaTime, jspeed * Time.deltaTime, vertical * speed * Time.deltaTime);
        cc.Move(dir);

    }
    
    
}