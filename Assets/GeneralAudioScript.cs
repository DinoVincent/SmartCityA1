using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class GeneralAudioScript : MonoBehaviour
{
    public static GeneralAudioScript instance;
    public AudioSource[] audios;

    void Awake(){
        if(instance==null) instance= this;

        foreach (AudioSource s in audios){
            s.playOnAwake =false;
        }
    }

    public void playAudio(int index){
        audios[index].Play();

    }

}
