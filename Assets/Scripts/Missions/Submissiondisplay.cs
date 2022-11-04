using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Submissiondisplay : MonoBehaviour
{

    public TMP_Text Title, progress;
    public Image panel;
    public enum colorOption {progressc, locked, completed}
    public Color progressc, locked, completed;
    private float _currentpercentage=-1;

    public void updateTitle(string title){
        Title.text = title;

    }

    public void updateProgress(string text, float percentage, colorOption color, bool tween=false){
        progress.text = text;
        if (!tween)
        panel.fillAmount = percentage;
        else {
            if(_currentpercentage != percentage){
                if (_currentpercentage == -1) {_currentpercentage = percentage; panel.fillAmount = percentage;}
                else{
                _currentpercentage = percentage;
                LeanTween.value(this.gameObject, UpdateBar, panel.fillAmount, percentage, .2f);
                }
            }
        }
        switch(color){
            case colorOption.completed:
                panel.color = completed;
            break;
            case colorOption.locked:
                panel.color = locked;
            break;
            case colorOption.progressc:
                panel.color = progressc;
            break;
        }
    }

    void UpdateBar(float val, float ratio){ 
        panel.fillAmount = val;

    }

}
