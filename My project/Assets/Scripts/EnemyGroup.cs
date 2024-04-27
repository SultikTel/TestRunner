using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGroup : MonoBehaviour
{
    public Action onSpotCleared;
    [SerializeField] private Enemy[] ememiesOnSpot;
    private int deathCount;
    private void Start()
    {
        foreach(Enemy en in ememiesOnSpot)
        {
            en.onDeath += CheckAnyEnemiesLeft;
        }
    }

    public void CheckAnyEnemiesLeft()
    {
        deathCount++;
        if (deathCount == ememiesOnSpot.Length)
        {
            Debug.Log("gg");
            onSpotCleared?.Invoke();
        }
    }

    public bool IsAlreadyPassed()
    {
        return deathCount == ememiesOnSpot.Length;
    }


}
