using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void MexicoScene(){
        Invoke("sceneswitch", 2f);

    }


    void sceneswitch(){
        GameSceneManager.instance.LoadMexico();
    }
}
