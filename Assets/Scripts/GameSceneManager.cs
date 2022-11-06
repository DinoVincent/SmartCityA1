using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;
    public GameObject LoadingScreen;
    public GameObject Missionhandler;
    float totalprogress;
    public Image bar;
    public Material skyboxNewYork;
    public Material skyboxMexico;
    void Awake()
    {
        instance= this;
        RenderSettings.skybox = skyboxNewYork;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        
        Missionhandler.SetActive(true);
        LoadingScreen.SetActive(false);
    }
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadMexico(){
        StartCoroutine(loadmex());
    }
    public IEnumerator loadmex (){
        LoadingScreen.SetActive(true);
        Missionhandler.SetActive(false);

        yield return new WaitForSeconds(2f);
        RenderSettings.skybox = skyboxMexico;
        scenesLoading.Add(SceneManager.UnloadSceneAsync(1));
        scenesLoading.Add(SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive));
        StartCoroutine(GetProgress());

    }

    public IEnumerator GetProgress()
    {
        for(int i=0; i<scenesLoading.Count; i++){
            while(!scenesLoading[i].isDone){

                totalprogress = 0;
                foreach(AsyncOperation op in scenesLoading){
                    Debug.Log(op.progress);
                    totalprogress += op.progress;
                }
                totalprogress = (float)(totalprogress / scenesLoading.Count);

                bar.fillAmount = totalprogress;
                yield return null;
            }
        }
        yield return new WaitForSeconds(3f);
        LoadingScreen.SetActive(false);
        Missionhandler.SetActive(true);

    }
}
