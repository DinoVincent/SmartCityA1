using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubMission : missionclass

{


    public GameObject visual;
    public enum missionType {movement}
    public missionType type = missionType.movement;
    public bool lockBefore;
    public MovementMission movement;

    public new void updateMission(){
            switch(type){
                case missionType.movement:
                    movement.updateMission(this);
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
            Debug.Log(i);
            if(i != index){
                amountTotal++;
                if(list[i].state == missionclass.missionState.Completed) amountCompleted++;
                if(list[i].lockBefore) break;
            }
        }
            Debug.Log(amountCompleted+"/"+amountTotal);
            if(amountCompleted!=amountTotal) return missionState.Locked;
            else return missionState.Ongoing;
       }
    public void forceUIupdate(){
        switch(type){
                case missionType.movement:
                    movement.updateUI(this);
                    break;
            }
    }

}



