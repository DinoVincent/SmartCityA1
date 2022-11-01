using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubMission
{
    public enum missionType {movement}

    public missionType type = missionType.movement;

    public MovementMission movement;




}
