using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public MissionDisplayer msd;
    public HeadMission[] activeMissions;
    public List<HeadMission> completedMissions;
    

    void Update(){
        foreach (HeadMission h in activeMissions){
            bool completed=true;
            if(h.state != missionclass.missionState.Hidden && !h._displayed){
                h._displayed=true;
                h.visual = msd.CreateMission(h);
            }
            if(h.state == missionclass.missionState.Ongoing)
                h.updateMission(); 

            if(h.state == missionclass.missionState.Locked && !h._ddisbabled){
                h.lockUpdate();
            }

            foreach(SubMission s in h.subMissions){
                if(s.state != missionclass.missionState.Completed) completed=false;
                }
            if (completed && h.state != missionclass.missionState.Completed) makeComplete(h);

        }
    }
    void makeComplete(HeadMission h){
        h.state = missionclass.missionState.Completed;
        h.visual.SetActive(false);
        h.visualdone = msd.MissionDone(h);
    }
}
