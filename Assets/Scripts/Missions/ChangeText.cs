using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TMP_Text textv;

    public void ChangePop(string text, bool animate=false){
        
        textv.text = text;
    }
}