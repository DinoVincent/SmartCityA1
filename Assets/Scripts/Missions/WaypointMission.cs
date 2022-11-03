using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaypointMission {
    public Submissiondisplay subd;
    public Transform waypoint;
    public float radius;
    private Transform cam_;
 public void updateMission(SubMission sub){
    if (cam_ == null) cam_ = Camera.main.transform;
    if(sub.state == missionclass.missionState.Ongoing){
            float dis= Vector3.Distance(cam_.position, waypoint.position);
        if(dis <= radius){
            sub.state = missionclass.missionState.Completed;
        }
        updateUI(sub, null, dis);
    }
    if(sub.state != missionclass.missionState.Completed || sub.state != missionclass.missionState.Hidden){
      updateUI(sub);
    }
  }

  public void updateUI(SubMission sub, HeadMission hd=null, float Distance=-1){
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
            if(Distance != -1)
            if(Distance <= radius*2){
                float displayDis = ((radius*2-Distance)/radius);
                //Debug.Log(displayDis);
                subd.updateProgress("To-Do", displayDis, Submissiondisplay.colorOption.progressc);
            } else {
                subd.updateProgress("To-Do", 0f, Submissiondisplay.colorOption.progressc);
            }

        }

    }
    
  }


   

