using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CreatePopUp : MonoBehaviour
{
    public GameObject PopUP;
    public Transform startpoint, endpoint, target;
    public CanvasGroup canvasg;
    public MissionHandler mis;

    

    

    public void createPopUp(){
        canvasg.alpha = 0f;
        GameObject pop = Instantiate(PopUP, startpoint.position, Quaternion.identity ,target);
        int currentRecent=0;
        for(int i = 0; i<mis.activeMissions.Length; i++){
            if(mis.activeMissions[i].state == missionclass.missionState.Ongoing){
                currentRecent = i; break;
            }
        }


        pop.GetComponent<ChangeText>().textv.text = mis.activeMissions[currentRecent].Name;
        LeanTween.alphaCanvas(canvasg, 1f, .2f);
        LeanTween.move(pop, endpoint, .2f);
        StartCoroutine(vanishPop(pop));
    }

        IEnumerator vanishPop(GameObject pop){
        yield return new WaitForSeconds(5f);
        LeanTween.alphaCanvas(canvasg, 1f, .4f);
        LeanTween.move(pop, startpoint, .2f);
        Destroy(pop,1f);
    }

}
