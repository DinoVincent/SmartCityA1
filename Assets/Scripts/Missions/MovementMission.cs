using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class MovementMission 
{
  
  public KeyCode key;
  public float KeyPressTime;
  public float _timepressed;
  public bool jumpkey=false;
  bool _event=false;
  public Submissiondisplay subd;
  private missionclass.missionState _state;

  
  void Jump(){
    if(_state == missionclass.missionState.Ongoing){
      _timepressed+=1f;
    }
  }

 public void updateMission(SubMission sub){
    if(!_event && jumpkey) {PlayerMovement.jumpevent.AddListener(Jump); _event=true;}
    if(_state != sub.state) _state = sub.state;

    if(sub.state == missionclass.missionState.Ongoing){
      if(Input.GetKey(key) && !jumpkey){
          _timepressed+=Time.deltaTime;
      }

      if(_timepressed >= KeyPressTime){
          sub.state = missionclass.missionState.Completed;
          _timepressed = KeyPressTime;
          updateUI(sub);
      }
    }
    if(sub.state != missionclass.missionState.Completed || sub.state != missionclass.missionState.Hidden){
      updateUI(sub);
    }
  }

  public void updateUI(SubMission sub, HeadMission hd=null){
    if (subd == null) subd=sub.visual.GetComponent<Submissiondisplay>();
    if (hd!=null){
      if(hd.state == missionclass.missionState.Locked){
        sub.state = missionclass.missionState.Locked;
      }
    }
    if(sub.state == missionclass.missionState.Locked)
    subd.updateProgress("Locked", 1f, Submissiondisplay.colorOption.locked);
    else if(sub.state == missionclass.missionState.Completed)
    subd.updateProgress("Completed", 1f, Submissiondisplay.colorOption.completed);
    else if(sub.state == missionclass.missionState.Ongoing){
      if(!jumpkey)
      subd.updateProgress(_timepressed.ToString("F1")+"/"+ KeyPressTime.ToString("F1"), (float)(_timepressed/KeyPressTime), Submissiondisplay.colorOption.progressc);
      else
      subd.updateProgress(_timepressed.ToString()+"/"+ KeyPressTime.ToString(), (float)(_timepressed/KeyPressTime), Submissiondisplay.colorOption.progressc);
    }
    
  }
}


