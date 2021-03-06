﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(transform != GameManager._instance.targets[GameManager._instance.targets.Length - 1])
            {
                enemy.FindPath(enemy.indexTarget + 1);
                enemy.indexTarget++;
            }
            else
            {
                enemy.target = GameManager._instance.humanTargets[0];
            }
        }
    }
}
