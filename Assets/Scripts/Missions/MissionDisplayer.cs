using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Mission, Submission, target;
    [SerializeField]
    private GameObject missiondone,targetdone;
   
    public GameObject CreateMission(HeadMission HM){
        GameObject _hvisual = Instantiate(Mission, new Vector3(0,0,0), Quaternion.identity, target.transform);
        HeadMissionText Htext = _hvisual.GetComponent<HeadMissionText>();
        Htext.ChangeText(HM.Name);
        Transform tsub =  Htext.target.transform;
        for(int i=0; i<HM.subMissions.Length; i++){
            GameObject _svisual = Instantiate(Submission, new Vector3(0,0,0), Quaternion.identity, tsub.transform);
            _svisual.GetComponent<Submissiondisplay>().updateTitle(HM.subMissions[i].Name);
            HM.subMissions[i].visual = _svisual;
            //if(HM.subMissions[i].state == missionclass.missionState.Hidden) _svisual.SetActive(false);
        }
        Invoke("refresh", 0.3f);
        
        return _hvisual;
    }
    public GameObject MissionDone(HeadMission HM){
        GameObject _hvisual = Instantiate(missiondone, new Vector3(0,0,0), Quaternion.identity, targetdone.transform);
        HeadMissionText Htext = _hvisual.GetComponent<HeadMissionText>();
        Htext.ChangeText(HM.Name);
        Invoke("refresh", 0.3f);
        return _hvisual;
    }
    public void refresh(){
        if(target.activeSelf){
            target.SetActive(false);
            target.SetActive(true);
            targetdone.SetActive(false);
            targetdone.SetActive(true);
        }
    }
    
    
}
