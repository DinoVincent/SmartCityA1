using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField]
    GameObject missionMenu, backdrop;
    bool _open;
    [SerializeField]
    CanvasGroup Mission;
    


    void Start(){
        missionMenu.SetActive(false);
        if(missionMenu.activeSelf) _open = true; else _open = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_open)
            {
                Mission.alpha=1f;
                Cursor.lockState = CursorLockMode.Locked;
                LeanTween.alphaCanvas(Mission, 0f, .2f);
                LeanTween.scale(backdrop, new Vector3(.5f,.5f,.5f), .15f);
                _open=false;

            }
            else
            {   missionMenu.SetActive(false);
                Mission.alpha=0f;
                missionMenu.SetActive(true);
                missionMenu.SetActive(false);
                missionMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                LeanTween.alphaCanvas(Mission, 1f, .2f);
                LeanTween.scale(backdrop, new Vector3(1,1,1), .15f);
                _open=true;
            }
        }
    }
}
