using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HeadMissionText : MonoBehaviour
{
    public TMP_Text textv;
    public GameObject target;
    private VerticalLayoutGroup layoutgroup;
    void Awake(){
        layoutgroup =this.GetComponentInParent<VerticalLayoutGroup>();
        Debug.Log(layoutgroup);
    }
    public void ChangeText(string text, bool animate=false){
        
        textv.text = text;
        if (animate){
            layoutgroup.enabled= false;
            transform.localPosition = new Vector3 (500,-1.5f,0);
            LeanTween.moveLocal(this.gameObject, new Vector3 (50,-1.5f,0), .2f);
            Invoke("enableLayoutGR", .2f);
        }
    }

    public void enableLayoutGR(){
        layoutgroup.enabled= true;

    }
}
