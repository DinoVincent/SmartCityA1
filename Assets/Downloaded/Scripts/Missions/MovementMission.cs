using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementMission 
{
  public KeyCode key;
  public float KeyPressTime;
  public float _timepressed;

 public void updateMission(SubMission sub){
    if(Input.GetKey(key)){
        _timepressed+=Time.deltaTime;
    }

    if(_timepressed >= KeyPressTime){
        sub.state = missionclass.missionState.Completed;
        _timepressed = KeyPressTime;
    }

  }
  
}


