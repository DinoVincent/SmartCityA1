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

    public void updateTitle(string title){
        Title.text = title;

    }

    public void updateProgress(string text, float percentage, colorOption color){
        progress.text = text;
        panel.fillAmount = percentage;
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
}
