using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class missionclass
{
    public  enum missionState {Hidden, Ongoing, Completed}
[SerializeField]
 public string Name, description;
 public missionState state=missionState.Hidden;


public void updateMission(){}
}
