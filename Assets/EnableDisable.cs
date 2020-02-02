using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    bool enabled = true;
    public GameObject menu;
    
    public void EnDis()
    {
        if (enabled)
        {
            menu.SetActive(false);
            enabled = false;
        }
        else
        {
            menu.SetActive(true);
            enabled = true;
        }
    }
}
