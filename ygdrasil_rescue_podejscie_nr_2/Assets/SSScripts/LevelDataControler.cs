using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataControler : MonoBehaviour
{
    public int[] stagesWithEnemy;
    public char[] enemyTypes;
    public int enemyCount;
    public int lastStage;
    public int minMove;

    private void Awake()
    {
        LoadLevel(PlayerPrefs.GetInt("LevelToLoad"));
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
        stagesWithEnemy = new int[] { 3, 7, 10, 15, 19 };
        enemyTypes = new char[] { 'w', 'w', 'd', 'w', 'd' };
        enemyCount = stagesWithEnemy.Length;
        lastStage = 23;
        minMove = countMinMove();
    }

    void secendLevel()
    {
        stagesWithEnemy = new int[] { 4, 7, 11, 14, 18, 22, 26 };
        enemyTypes = new char[] { 'd', 'd', 'w', 'w', 'd', 'w', 'w' };
        enemyCount = stagesWithEnemy.Length;
        lastStage = 29;
        minMove = countMinMove();
    }

    int countMinMove()
    {
        int CMM;
        CMM = lastStage;
        foreach ( char type in enemyTypes)
        {
            if (type=='w')
            {
                CMM += 2;
            }
            else if (type=='d')
            {
                CMM += 3;
            }
        }
        return CMM;
    }

}
