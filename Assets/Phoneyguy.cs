using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phoneyguy : MonoBehaviour
{
    public string input;
    public TMP_Text text;
    public GameObject phoneUI;

    public GameObject missionUI;
    public Tab Missiontab;





    public void Update(){
        if(text.text != input) text.text = input;
    }

    public void clear(){
        input = "";
    }

    public void addString(string n){
        if(input.Length < 10)
        input += n;
    }

    public void Call(){
        if(input == "911"){
            callevent.call = true;
            staticgamesaver.allowMovement = false;
        } else {
            input = "The number u have dialed is invalid.";
        }
    }

    public void openPhone(){
        Missiontab.voidForceClose();
        missionUI.SetActive(false);
        Missiontab.switchLockOpeningState(true, true);
        phoneUI.SetActive(true);
    }

    public void closePhone(bool allowTAB=false){
        if(allowTAB)
        Missiontab.switchLockOpeningState(true, false);
        else Missiontab.switchLockOpeningState(true, true);
        phoneUI.SetActive(false);

    }   

}
