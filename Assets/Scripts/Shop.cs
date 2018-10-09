﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public Text scoreText;
    public Text costText;
    public int costHealHumans, costUpgradeDamage, costUpgradeCadence;

    //Shop
    int timesHealHumans = 1, timesUpgradeDamage = 1, timesUpgradeCadence = 1;
    int currentButton = 0;
    public int limitUpgradeDamage, limitUpgradeCadence;
    int score = 0;
    int cost = 0;

    //Modifiers
    FPS player;
    public List<NPC> humans = new List<NPC>();

    private void Start()
    {
        player = FindObjectOfType<FPS>();
        score = GameManager._instance.score;
        scoreText.text = "Score : "+ score.ToString();
    }

    public void HealHumans()
    {
        if (currentButton != 1)
        {
            currentButton = 1;
            cost = timesHealHumans * costHealHumans;
            costText.text = "Cost : " + cost.ToString();
            score = GameManager._instance.score;
        }
        else
        {
            //Confirm
        }
    }
    public void UpgradeDamage()
    {
        if (currentButton != 2)
        {
            currentButton = 2;
            cost = timesUpgradeDamage * costUpgradeDamage;
            costText.text = "Cost : " + cost.ToString();
            score = GameManager._instance.score;
        }
        else
        {
            //Confirm
            player.damage++;
            GameManager._instance.Buy(cost);
            score = GameManager._instance.score;
            scoreText.text = "Score : " + GameManager._instance.score.ToString();
        }
    }
    public void UpgradeCadence()
    {
        if (currentButton != 3)
        {
            currentButton = 3;
            cost = timesUpgradeCadence * timesUpgradeCadence;
            if(player.cadence -0.03f > 0)
                costText.text = "Cost : " + cost.ToString();
            else
                costText.text = "You have the minimun cadence";
            score = GameManager._instance.score;
        }
        else
        {
            //Confirm
            if(player.cadence - 0.03f > 0)
            {
                player.cadence -= 0.03f;
                GameManager._instance.Buy(cost);
                score = GameManager._instance.score;
                scoreText.text = "Score : " + GameManager._instance.score.ToString();
            }
            else
            {
                costText.text = "You have the minimun cadence";
            }
        }
    }
    public void CloseShop()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }
}