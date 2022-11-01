using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
   public float mouseSensitivity = 100f;
   public Transform Playerbody;
   float xRotation = 0f;
   bool active= false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Invoke("enableCam", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!active) return;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        if (Cursor.lockState == CursorLockMode.Locked)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }

    void enableCam(){
        active = true;
    }
}
