using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUI : MonoBehaviour
{
    public GameObject canvas;
    public CanvasGroup canvasgr;
    public MissionHandler missionHandler;
    public CreatePopUp pop;
    public SceneSwitcher sc;
    public Tab tab;
    public void OpenUI(){
        Cursor.lockState = CursorLockMode.None;
        tab.switchLockOpeningState(true, true);
        tab.voidForceClose();
        canvasgr.alpha=0f;
        canvas.SetActive(true);
        LeanTween.alphaCanvas(canvasgr, 1f, .2f);
    }

    public void Stay(){
        Cursor.lockState = CursorLockMode.Locked;
        LeanTween.alphaCanvas(canvasgr, 0f, .2f);
        tab.switchLockOpeningState(true, false);
        missionHandler.MakeNextHiddenBatteryToGoing();
        pop.createPopUp(true);

        
    }

    public void Look(){
        Cursor.lockState = CursorLockMode.Locked;
        sc.MexicoScene();
    }
}
