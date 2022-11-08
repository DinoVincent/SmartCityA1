using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class callevent
{
  [System.NonSerialized]
    public Submissiondisplay subd;
    public static bool call=false;
 public void updateMission(SubMission sub){
    if(sub.state == missionclass.missionState.Ongoing){
        if(call) sub.state = missionclass.missionState.Completed;
        updateUI(sub, null);
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
                subd.updateProgress("TO-DO", 0f, Submissiondisplay.colorOption.progressc);

        }

    }
}
