using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    [SerializeField]
    float rotatingSpeed=1;
    void Update()
    {
        this.transform.Rotate(transform.forward, Time.deltaTime * rotatingSpeed);
    }
}
