﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    public void Pause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            GameManager._instance.pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            GameManager._instance.pausePanel.SetActive(true);
        }
    }
}