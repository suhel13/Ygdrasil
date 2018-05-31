using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataControler : MonoBehaviour
{
    public int[] stagesWithEnemy;
    public char[] enemyTypes;
    public JsonData LevelStats = new JsonData();
    public int enemyCount;
    public int lastStage;
    public int minMove;
    LevelData level1;
    LevelData level2;

    private void Awake()
    {
        // PlayerPrefs.DeleteKey("LevelStats");
        if (PlayerPrefs.HasKey("LevelStats"))
        {
            LevelStats.Stars = JsonUtility.FromJson<JsonData>(PlayerPrefs.GetString("LevelStats")).Stars;
            LevelStats.Time = JsonUtility.FromJson<JsonData>(PlayerPrefs.GetString("LevelStats")).Time;
        }
        else
        {
            PlayerPrefs.SetString("LevelStats", JsonUtility.ToJson(LevelStats));
            PlayerPrefs.Save();
        }
        level1 = new LevelData(new int[] { 3, 7, 8, 13, 17 }, new char[] { 'w', 'w', 'd', 'w', 'd' }, 20);
        level2 = new LevelData(new int[] { 4, 7, 11, 14, 18, 22, 26 }, new char[] { 'd', 'd', 'w', 'w', 'd', 'w', 'w' }, 29);


        LoadLevel(PlayerPrefs.GetInt("LevelToLoad")); // this is set by button on map
    }

    void LoadLevel(int number)
    {
        switch (number)
        {
            case 1:
                loadLevelData(level1);
                break;
            case 2:
                loadLevelData(level2);
                break;
            default:
                break;
        }
    }

    void loadLevelData(LevelData level)
    {
        stagesWithEnemy = level.stagesWithEnemy;
        enemyTypes = level.enemyTypes;
        enemyCount = level.enemyCount;
        lastStage = level.lastStage;
        minMove = level.minMove;
    }
}
