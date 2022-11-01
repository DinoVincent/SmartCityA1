using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    [SerializeField]
    public MovementMission[] ActiveMissions;
   
    void Update(){
        updateActiveMissions();
    }

    void updateActiveMissions(){
        for(int i=0; i<ActiveMissions.Length; i++){
            ActiveMissions[i].updateMission();
        }
    }
}
