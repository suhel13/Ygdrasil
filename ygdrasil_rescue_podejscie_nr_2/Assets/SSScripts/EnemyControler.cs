using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControler : MonoBehaviour
{

    public List<int> stagesWithEnemy = new List<int>();
    public GameObject enemyPrefab;
    public LevelDataControler levelData;
    public Enemy enemy;
    public Image hpBar;
    int enemyIndex=0;
    // Use this for initialization
    void Start()
    {
        countEnemyStages(levelData.enemyCount);
    }

    void countEnemyStages(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            stagesWithEnemy.Add(levelData.stagesWithEnemy[i]);
        }
    }

    public Enemy spawnEnemy()
    {
        enemy= Instantiate<GameObject>(enemyPrefab, new Vector2(6, 0), Quaternion.identity).GetComponent<Enemy>();
        enemy.hpBar = hpBar;
        if (levelData.enemyTypes[enemyIndex]=='w')
        {
            enemy.transmutateTo("Wolf");
        }
        else if (levelData.enemyTypes[enemyIndex]=='d')
        {
            enemy.transmutateTo("Draug");
        }
        enemyIndex++;
        enemy.updateHpBar();
        return enemy;
    }
}
