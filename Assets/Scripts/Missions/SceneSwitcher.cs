using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void MexicoScene(){
        Invoke("sceneswitch", 2f);

    }


    void sceneswitch(){
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
