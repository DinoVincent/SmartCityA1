using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missionhandler : MonoBehaviour
{
    public MissionDisplayer msd;
    public HeadMission[] activeMissions;
    

    void Update(){
        foreach (HeadMission h in activeMissions){
            if(h.state != missionclass.missionState.Hidden && !h._displayed){
                h._displayed=true;
                h.visual = msd.CreateMission(h);
            }
            if(h.state == missionclass.missionState.Ongoing)
                h.updateMission(); 
        }
    }
}
