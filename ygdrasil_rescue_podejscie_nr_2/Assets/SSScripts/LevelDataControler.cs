﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataControler : MonoBehaviour
{
    public int[] stagesWithEnemy;
    public char[] enemyTypes;
    public List<JsonData> Stars=new List<JsonData>();
    public int enemyCount;
    public int lastStage;
    public int minMove;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Stars"))
        {
            Stars = JsonUtility.FromJson<List<JsonData>>(PlayerPrefs.GetString("Stars"));
        }
        else
        {
            PlayerPrefs.SetString("Stars", JsonUtility.ToJson(Stars));
            PlayerPrefs.Save();
        }
        LoadLevel(PlayerPrefs.GetInt("LevelToLoad")); // this is set by button on map
    }

    void LoadLevel(int number)
    {
        switch (number)
        {
            case 1:
                firstLevel();
                break;
            case 2:
                secendLevel();
                break;
            default:
                break;
        }
    }

    void firstLevel()
    {
        stagesWithEnemy = new int[] { 3, 7, 8, 13, 17 };
        enemyTypes = new char[] { 'w', 'w', 'd', 'w', 'd' };
        enemyCount = stagesWithEnemy.Length;
        lastStage = 20;
        minMove = countMinMove();
        if (Stars.Count<1)
        {
            Stars.Add(new JsonData());
        }
    }

    void secendLevel()
    {
        stagesWithEnemy = new int[] { 4, 7, 11, 14, 18, 22, 26 };
        enemyTypes = new char[] { 'd', 'd', 'w', 'w', 'd', 'w', 'w' };
        enemyCount = stagesWithEnemy.Length;
        lastStage = 29;
        minMove = countMinMove();
        if (Stars.Count < 2)
        {
            Stars.Add(new JsonData());
        }
    }

    int countMinMove()
    {
        int CMM;
        CMM = lastStage;
        foreach (char type in enemyTypes)
        {
            if (type == 'w')
            {
                CMM += 2;
            }
            else if (type == 'd')
            {
                CMM += 3;
            }
        }
        return CMM;
    }

}
