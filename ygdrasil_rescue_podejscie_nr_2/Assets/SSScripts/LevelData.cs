using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int[] stagesWithEnemy ;
    public char[] enemyTypes;
    public int enemyCount ;
    public int lastStage;
    public int minMove;
   
    public LevelData(int[] stagWithEne,char[] EneType,int lastStag)
    {
        stagesWithEnemy = stagWithEne;
        enemyTypes = EneType;
        enemyCount = stagesWithEnemy.Length;
        lastStage = lastStag;
        minMove = countMinMove();
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
