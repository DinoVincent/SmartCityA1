using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatiedeur : MonoBehaviour
{
    Animator animator;
    bool isopen;

    void Start(){
        animator = GetComponent<Animator>();
        isopen = false;
    }
    public void Openen() {
        if(isopen == false ) {
         animator.SetTrigger("open");
        isopen = true;

        } else {
        animator.SetTrigger("sluit");
        isopen = false;     
        }
      
    }
}
