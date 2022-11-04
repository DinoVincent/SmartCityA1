using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public MissionDisplayer msd;
    public HeadMission[] activeMissions;

    public UnityEvent EndMissions;
    //public List<HeadMission> completedMissions;


    void Update(){
        bool allcompleted=true;
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
            if(h.state != missionclass.missionState.Completed) allcompleted=false;
        }
        if (allcompleted) EndMissions.Invoke();
    }
    void makeComplete(HeadMission h){
        h.state = missionclass.missionState.Completed;
        h.visual.SetActive(false);
        h.visualdone = msd.MissionDone(h);
    }
    
}
