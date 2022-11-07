using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubMission : missionclass

{

    [System.NonSerialized]
    public GameObject visual;
    public enum missionType {movement, waypoint, interact, Wait, call}
    public missionType type = missionType.movement;
    public bool lockBefore;
    public MovementMission movement;
    public WaypointMission waypoint;
    public InteractMission interact;
    public WaitMission wait;
    public callevent call;

    public new void updateMission(){
            switch(type){
                case missionType.movement:
                    movement.updateMission(this);
                    break;
                case missionType.waypoint:
                    waypoint.updateMission(this);
                    break;
                case missionType.interact:
                    interact.updateMission(this);
                    break;
                case missionType.Wait:
                    wait.updateMission(this);
                    break;
                case missionType.call:
                    call.updateMission(this);
                    break;
            }
            
        

    }
    public missionState StillLock(SubMission[] list, int index){
           if(!lockBefore && index != 0){
                if(list[index-1].state == missionState.Ongoing)
                return missionState.Ongoing;
           }
            int amountCompleted=0, amountTotal=0;
        for(int i=index; 0 <= i; i--){
            //Debug.Log(i);
            if(i != index){
                amountTotal++;
                if(list[i].state == missionclass.missionState.Completed) amountCompleted++;
                if(list[i].lockBefore) break;
            }
        }
            //Debug.Log(amountCompleted+"/"+amountTotal);
            if(amountCompleted!=amountTotal) return missionState.Locked;
            else return missionState.Ongoing;
       }
    public void forceUIupdate(HeadMission hd=null){
        switch(type){
                case missionType.movement:
                    movement.updateUI(this, hd);
                    break;
                case missionType.waypoint:
                    waypoint.updateUI(this, hd);
                    break;
                case missionType.interact:
                    interact.updateUI(this, hd);
                    break;
                case missionType.Wait:
                    wait.updateUI(this,hd);
                    break;
                case missionType.call:
                    call.updateUI(this,hd);
                    break;
            }
    }

}



