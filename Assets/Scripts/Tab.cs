using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour
{
    [SerializeField]
    GameObject missionMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (missionMenu.activeSelf)
            {
                missionMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
               

            }
            else
            {
                missionMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
