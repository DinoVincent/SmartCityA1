using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class DoneMissionText : MonoBehaviour
{
    public TMP_Text textv;
    public void ChangeText(string text, bool animate=false){
        
        textv.text = text;
        if (animate){
            transform.localPosition = new Vector3 (500,-1.5f,0);
            LeanTween.moveLocal(this.gameObject, new Vector3 (50,-1.5f,0), .2f);
        }
    }

}
