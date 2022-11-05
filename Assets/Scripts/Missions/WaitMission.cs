using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaitMission
{
  [System.NonSerialized]
  public Submissiondisplay subd;
  public float TimeT;
  private float _timepassed;
 public void updateMission(SubMission sub){
    if(sub.state == missionclass.missionState.Ongoing){
        _timepassed += Time.deltaTime;
        if(_timepassed >= TimeT){
            sub.state = missionclass.missionState.Completed;
            _timepassed = TimeT;
        }
        updateUI(sub);

    }
    if(sub.state != missionclass.missionState.Completed || sub.state != missionclass.missionState.Hidden){
      updateUI(sub);
    }
  }

  public void updateUI(SubMission sub, HeadMission hd=null, bool tween =false){
    if (subd == null) subd=sub.visual.GetComponent<Submissiondisplay>();
    if (hd!=null){
      if(hd.state == missionclass.missionState.Locked){
        sub.state = missionclass.missionState.Locked;
      }
    }
    if(sub.state == missionclass.missionState.Locked)
    subd.updateProgress("Locked", 1f, Submissiondisplay.colorOption.locked);
    else if(sub.state == missionclass.missionState.Completed){
      if(!tween)
        subd.updateProgress("Done", 1f, Submissiondisplay.colorOption.completed);
      else subd.updateProgress("Done", 1f, Submissiondisplay.colorOption.completed, true);
    }
    else if(sub.state == missionclass.missionState.Ongoing){
        subd.updateProgress((TimeT-_timepassed).ToString("0"), (float)(1-(_timepassed/TimeT)), Submissiondisplay.colorOption.progressc);
    }
    
  }
}

