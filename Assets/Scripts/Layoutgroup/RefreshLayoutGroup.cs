using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;  
using UnityEngine;

public class RefreshLayoutGroup : MonoBehaviour
{
    public LayoutGroup layoutGroup;

    void Start(){
        StartCoroutine(LateStart(.02f));
    }

     
     IEnumerator LateStart(float waitTime)
     {
        yield return new WaitForSeconds(waitTime);
        refresh();
     }

     void refresh(){
        layoutGroup.enabled = false;
        layoutGroup.enabled = true;
     }
}
