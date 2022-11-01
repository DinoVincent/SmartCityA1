using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementMission : Mission
{
  public KeyCode key;
  public float KeyPressTime;
  public float _timepressed;



 public new void updateMission(){
    if(state != missionState.Ongoing){return;}
    if(Input.GetKey(key)){
        _timepressed+=Time.deltaTime;
    }

    if(_timepressed >= KeyPressTime){
        state = missionState.Completed;
        _timepressed = KeyPressTime;
    }

  }


}

