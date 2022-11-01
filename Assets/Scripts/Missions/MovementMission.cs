using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementMission : missionclass
{
  /*public KeyCode key;
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
  */
    public KeyPress[] keys;
   

    public new void updateMission(){
    if(state != missionState.Ongoing){return;}

    int _amountCompleted=0;
    for(int i=0; i<keys.Length; i++){
        if (i==0) _amountCompleted = 0;
        if(Input.GetKey(keys[i].key)){
            keys[i]._timepressed+=Time.deltaTime;
        }

        if(keys[i]._timepressed >= keys[i].KeyPressTime){
            keys[i]._timepressed = keys[i].KeyPressTime;
            _amountCompleted++;
        }
    }

    if (_amountCompleted >= keys.Length) state = missionState.Completed;
    

    }
}

[System.Serializable]
public class KeyPress{
    public KeyCode key;
    public float KeyPressTime;
    public float _timepressed;
}