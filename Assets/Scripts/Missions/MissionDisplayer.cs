using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MissionDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject Mission, Submission, target;
    [SerializeField]
    private VerticalLayoutGroup targett;
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
        refresh();
        Invoke("refresh", 0.3f);
        
        return _hvisual;
    }
    public GameObject MissionDone(HeadMission HM){
        //VerticalLayoutGroup lay = targetdone.GetComponent<ver
        GameObject _hvisual = Instantiate(missiondone, new Vector3(0,0,0), Quaternion.identity, targetdone.transform);
        DoneMissionText Htext = _hvisual.GetComponent<DoneMissionText>();
        Htext.ChangeText(HM.Name, true);
        refresh();
        Invoke("refresh", 0.3f);
        return _hvisual;
    }
    public void refresh(){
        if(target.activeSelf){
            target.SetActive(false);
            target.SetActive(true);
            targetdone.SetActive(false);
            targetdone.SetActive(true);
            StartCoroutine(hardRefresh());
        }
    }

    IEnumerator hardRefresh(){
        targett.enabled = false;
        yield return new WaitForSecondsRealtime(.2f);
        targett.enabled = true;
    }

    
    
}
