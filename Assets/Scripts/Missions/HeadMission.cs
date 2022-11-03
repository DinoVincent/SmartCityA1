using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HeadMission : missionclass
{ 
    public GameObject visual, visualdone;
    public SubMission[] subMissions;
    [System.NonSerialized]
    public bool _displayed=false;
    [System.NonSerialized]
    public bool _ddisbabled=false;
    
    public new void updateMission(){

        bool done = true;
        foreach (SubMission s in subMissions){
            if (s.state != SubMission.missionState.Completed){
            done = false;
            break;
            }
        }

        if(done) {state = missionState.Completed; return;}

        for(int i = 0; i<subMissions.Length; i++){
            if(subMissions[i].state == SubMission.missionState.Completed) continue;
            if(subMissions[i].state == SubMission.missionState.Locked){
                subMissions[i].state=subMissions[i].StillLock(subMissions, i);
                subMissions[i].forceUIupdate();
            } else if(subMissions[i].state == SubMission.missionState.Ongoing) {
                subMissions[i].updateMission();
            }
        }

    }

    public void lockUpdate(){
            _ddisbabled=true;
            foreach(SubMission s in subMissions){
                s.forceUIupdate(this);
            }
        }

}
