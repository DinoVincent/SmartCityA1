using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class GeneralAudioScript : MonoBehaviour
{
    public static GeneralAudioScript instance;
    public audioclip[] audios;

    void Awake(){
        if(instance==null) instance= this;

        foreach (audioclip s in audios){
            s.audiosr.playOnAwake =false;
        }
    }

    public void playAudio(int index){
        audios[index].audiosr.Play();
    }

}

[System.Serializable]
public class audioclip {
    [SerializeField]
    public string Name;
    [SerializeField]
    public AudioSource audiosr;
}
