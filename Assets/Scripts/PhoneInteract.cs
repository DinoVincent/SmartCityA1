using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteract : MonoBehaviour
{
    public Phoneyguy phoneg;
    public GameObject Phone;
    public GameObject phoneUI;
    public float range;
    public LayerMask interactlayermask;

    void Update(){
        if (Input.GetKeyDown(KeyCode.E)){
            Camera cam = Camera.main;
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, interactlayermask)){
                Debug.Log(hit);
                if (hit.collider.gameObject == Phone){
                    phoneg.openPhone();
                }
            }
        } else if (Input.GetKeyDown(KeyCode.Escape)){
            if (phoneg.phoneUI.activeSelf){
                phoneg.closePhone();
            }
        }
    }

}
