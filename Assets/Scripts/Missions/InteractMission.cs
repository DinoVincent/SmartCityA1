using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InteractMission
{
    public GameObject target;
    public GameObject canvasTooltip;
    public bool RemoveTarget;
    public float Range;
    public LayerMask Hitmask;
    private Camera _cam;
    [System.NonSerialized]
    public Submissiondisplay subd;
 public void updateMission(SubMission sub){
    if (_cam == null) _cam = Camera.main;
    if(sub.state == missionclass.missionState.Ongoing){
        Ray(sub);
        updateUI(sub);
        
    }
    if(sub.state != missionclass.missionState.Completed || sub.state != missionclass.missionState.Hidden){
      updateUI(sub);
    }
  }

    void Ray(SubMission sub){
      RaycastHit hit;
      if(Physics.Raycast(_cam.transform.position, _cam.transform.forward,out hit, Range, Hitmask)){
          if(hit.collider.gameObject == target){
            canvasTooltip.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
              if(RemoveTarget)  target.SetActive(false);
              sub.state = missionclass.missionState.Completed;
              canvasTooltip.SetActive(false);
              updateUI(sub);
            }
          }
      }else{
            canvasTooltip.SetActive(false);
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

