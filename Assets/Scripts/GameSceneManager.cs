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
    public MissionHandler ms;
    public CreatePopUp cpu;
    float totalprogress;
    public Image bar;
    public Material skyboxNewYork;
    public Material skyboxMexico;
    public Tab tb;
    public GameObject MissionTargetsNY, MissionTargetsMexico;
    void Awake()
    {
        instance= this;
        RenderSettings.skybox = skyboxNewYork;
        Missionhandler.SetActive(true);
        LoadingScreen.SetActive(false);

        MissionTargetsNY.SetActive(true);
        MissionTargetsMexico.SetActive(false);
        
        
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        
        
      
    }
    void Start(){
        postprocessingManager.instance.startPostprocessing(postprocessingManager.profiles.profileNewYork);
       tb.voidForceOpen();
    }
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadMexico(){
        StartCoroutine(loadmex());
    }
    public IEnumerator loadmex (){
        LoadingScreen.SetActive(true);
        Missionhandler.SetActive(false);

        MissionTargetsNY.SetActive(false);
        MissionTargetsMexico.SetActive(true);
        postprocessingManager.instance.startPostprocessing(postprocessingManager.profiles.profileMexico);
        yield return new WaitForSeconds(2f);
        RenderSettings.skybox = skyboxMexico;
        postprocessingManager.instance.resetwhite();
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
        StartCoroutine(mexicoMissie());

    }

    public IEnumerator mexicoMissie(){
        yield return new WaitForSeconds(1f);
        ms.MakeNextHiddenToOngoing();
        cpu.createPopUp();
        
    }
}
