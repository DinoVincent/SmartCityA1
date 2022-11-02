using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementMission 
{
  public KeyCode key;
  public float KeyPressTime;
  public float _timepressed;

  public Submissiondisplay subd;
 public void updateMission(SubMission sub){
    
    if(sub.state == missionclass.missionState.Ongoing){
      if(Input.GetKey(key)){
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

  public void updateUI(SubMission sub){
    if (subd == null) subd=sub.visual.GetComponent<Submissiondisplay>();

    if(sub.state == missionclass.missionState.Locked)
    subd.updateProgress("Locked", 1f, Submissiondisplay.colorOption.locked);
    else if(sub.state == missionclass.missionState.Completed)
    subd.updateProgress("Completed", 1f, Submissiondisplay.colorOption.completed);
    else if(sub.state == missionclass.missionState.Ongoing){
     
      subd.updateProgress(_timepressed.ToString("F1")+"/"+ KeyPressTime.ToString("F1"), (float)(_timepressed/KeyPressTime), Submissiondisplay.colorOption.progressc);
    }
    
  }
}


