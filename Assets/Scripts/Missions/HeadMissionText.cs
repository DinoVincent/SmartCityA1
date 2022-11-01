using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeadMissionText : MonoBehaviour
{
    public TMP_Text textv;
    public GameObject target;
    public void ChangeText(string text){
        textv.text = text;
    }
}
