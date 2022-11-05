using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public MissionDisplayer msd;
    public HeadMission[] activeMissions;
    public CreatePopUp cp;

    
    
    //public List<HeadMission> completedMissions;

    void Start(){
        cp.createPopUp();
    }

    void Update(){
        foreach (HeadMission h in activeMissions){
            if(h.state != missionclass.missionState.Hidden && !h._displayed){
                h._displayed=true;
                h.visual = msd.CreateMission(h);
            }
            if(h.state == missionclass.missionState.Ongoing)
                h.updateMission(this); 

            if(h.state == missionclass.missionState.Locked && !h._ddisbabled){
                h.lockUpdate();
            }
        }

    }

    public void makeComplete(HeadMission h){
        h.state = missionclass.missionState.Completed;
        h.visual.SetActive(false);
        h.visualdone = msd.MissionDone(h);
    }

    public void MakeNextHiddenToLocked(){
        for(int i =0; i<activeMissions.Length; i++){
            if(activeMissions[i].state == missionclass.missionState.Hidden && !activeMissions[i].Battery){
                activeMissions[i].state = missionclass.missionState.Locked;
                break;
            }
        }
    }

    public void MakeNextHiddenToOngoing(){
        for(int i =0; i<activeMissions.Length; i++){
            if(activeMissions[i].state == missionclass.missionState.Hidden && !activeMissions[i].Battery) {
                activeMissions[i].state = missionclass.missionState.Ongoing;
                break;
            }
        }
    }

        public void MakeNextLockedToOngoing(){
        for(int i =0; i<activeMissions.Length; i++){
            if(activeMissions[i].state == missionclass.missionState.Locked && !activeMissions[i].Battery){
                activeMissions[i].state = missionclass.missionState.Ongoing;
                break;
            }
        }
    }

    public void MakeNextHiddenBatteryToGoing(){
        for(int i =0; i<activeMissions.Length; i++){
            if(activeMissions[i].state == missionclass.missionState.Hidden && activeMissions[i].Battery){
                activeMissions[i].state = missionclass.missionState.Ongoing;
                break;
            }
        }
    }
    
}
