using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Mission, Submission, target;
   
    public GameObject CreateMission(HeadMission HM){
        GameObject _hvisual = Instantiate(Mission, new Vector3(0,0,0), Quaternion.identity, target.transform);
        HeadMissionText Htext = _hvisual.GetComponent<HeadMissionText>();
        Htext.ChangeText(HM.Name);
        Transform tsub =  Htext.target.transform;
        for(int i=0; i<HM.subMissions.Length; i++){
            GameObject _svisual = Instantiate(Submission, new Vector3(0,0,0), Quaternion.identity, tsub.transform);
            _svisual.GetComponent<TMP_Text>().text = HM.subMissions[i].Name;
            HM.subMissions[i].visual = _svisual;
        }
        
        Invoke("refresh", 0.1f);
        return _hvisual;
    }

    public void refresh(){
        if(target.activeSelf){
            target.SetActive(false);
            target.SetActive(true);
        }
    }
    
    
}
