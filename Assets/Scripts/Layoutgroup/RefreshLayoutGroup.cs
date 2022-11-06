using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;  
using UnityEngine;

public class RefreshLayoutGroup : MonoBehaviour
{
    public LayoutGroup layoutGroup;

    void Start(){
         refresh();
        StartCoroutine(LateStart(1f));
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
