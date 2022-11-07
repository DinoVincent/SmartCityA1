using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine;

public class postprocessingManager : MonoBehaviour
{
    public enum profiles{profileNewYork, profileMexico};

    public static postprocessingManager instance;
    public PostProcessVolume volume;
    public PostProcessProfile profileNY, profileMexico;


    void Awake(){
        instance=this;
    }

    public void removePostprocesing(){
        volume.weight = 0f;
    }

    public void startPostprocessing(profiles p){
        if(p == profiles.profileNewYork) volume.profile = profileNY;
        if(p == profiles.profileMexico) volume.profile = profileMexico;
        volume.weight = 0.2f;
    }

    public void startGlitch(){
        LeanTween.value(this.gameObject, volumeTransfer, 0.2f, 1f, 7f);
    }

   public void startEnd(){
        LeanTween.value(this.gameObject, whiteScreen, 0, 120f, 4f);
   }


    void volumeTransfer(float val, float ratio){ 
        volume.weight = val;

    }
    public void resetwhite() { 
        ColorGrading grade = volume.profile.GetSetting<ColorGrading>();
        grade.postExposure.value = 0f;
        }
    void whiteScreen(float val, float ratio){
        ColorGrading grade = volume.profile.GetSetting<ColorGrading>();
        grade.postExposure.value = val;
        

    }
}
