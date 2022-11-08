using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public Camera entityCamera;
public CharacterController controller;
public float mouseSensitivity = 200f;
public float speed = 10f;
public float gravity = -12.81f;
public float Jumpheight = 0.3f;
public static float tpmultiplier = 1f;

public static UnityEvent jumpevent;
Vector3 velocity;


public Transform Groundcheck;
public float groundDistance = 0.6f;
public LayerMask groundMask;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        if (jumpevent == null)
            jumpevent = new UnityEvent();
    }
    void Update()
    {
        if(!staticgamesaver.allowMovement) return;
        bool isGrounded = Physics.CheckSphere(Groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime * tpmultiplier);


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpevent.Invoke();
            velocity.y = Mathf.Sqrt(Jumpheight * -2f * gravity * tpmultiplier);
        }




        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        if (mouseX != 0 && Cursor.lockState == CursorLockMode.Locked)
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.X)){
            if (Cursor.lockState == CursorLockMode.Locked) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
        }
    }

    
}
