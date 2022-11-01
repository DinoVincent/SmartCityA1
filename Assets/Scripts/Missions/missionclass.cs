using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class missionclass
{
[SerializeField]
 public string Name, description;
public  enum missionState {Hidden, Locked, Ongoing, Completed}
public missionState state=missionState.Hidden;


public void updateMission(){}


}
