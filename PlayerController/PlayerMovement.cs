using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 10f;
    public float jumpHeight = 10f;
    public float gravity = -9.8f;
    public float groundDistance = 0.4f;
    Vector3 velosity;
    bool isgrounded;

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isgrounded && velosity.y < 0)
        {
            velosity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");



        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velosity.y += gravity * Time.deltaTime;
        controller.Move(velosity * Time.deltaTime);

         if(Input.GetButtonDown("Jump")&& isgrounded)
        {
            velosity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
        }

        if(Input.GetKey("left ctrl"))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }
        
        if(Input.GetKey("left shift"))
        {
            speed = 15f;
        }
        else
        {
            speed = 10f;
        }
    }
}
