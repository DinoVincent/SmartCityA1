using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChooseUI : MonoBehaviour
{
    public GameObject canvas;
    public CanvasGroup canvasgr;
    public MissionHandler missionHandler;
    public CreatePopUp pop;
    public SceneSwitcher sc;
    public Tab tab;
    public Button but1, but2;

    IEnumerator delay(){
        yield return new WaitForSeconds(3f);
        GeneralAudioScript.instance.playAudio(1);
        yield return new WaitForSeconds(2.5f);
        Cursor.lockState = CursorLockMode.None;
        tab.switchLockOpeningState(true, true);
        tab.voidForceClose();
        canvasgr.alpha=0f;
        canvas.SetActive(true);
        LeanTween.alphaCanvas(canvasgr, 1f, .2f);
    }


    public void OpenUI(){
        StartCoroutine(delay());
    }

    public void Stay(){
        disableButton();
        Cursor.lockState = CursorLockMode.Locked;
        LeanTween.alphaCanvas(canvasgr, 0f, .2f);
        tab.switchLockOpeningState(true, false);
        missionHandler.MakeNextHiddenBatteryToGoing();
        pop.createPopUp(true);
        Invoke("Hidecanvas", .2f);
        
    }
    void disableButton(){
        but1.interactable = false;
        but2.interactable = false;
    }
    void Hidecanvas(){
        canvas.SetActive(false);

    }

    public void Look(){
        disableButton();
        Cursor.lockState = CursorLockMode.Locked;
         LeanTween.alphaCanvas(canvasgr, 0f, .2f);
        sc.MexicoScene();
        tab.switchLockOpeningState(true, false);
        Invoke("Hidecanvas", .2f);
    }
}
