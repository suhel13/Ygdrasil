using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{

    int actualStage = 0;
    public BackGGrounChange BGChange;
    public EnemyControler enemyControler;
    public UIControler uIControler;
    public ScenTransition scenTran;
    Enemy actualEnemy;
    public Image TimeBar;
    public Image HpBar;
    bool movedThisTurn = false;
    int hp = 4;
    int damage = 1;
    int lastStage;
    bool playerIsDodging = false;
    float turnTime = 1;
    float minTurnTime;
    float turnTimeStartValue;
    bool isAlive = true;
    bool enemyAttackedThisTurn = false;

    bool thisTurnPlayerTakeDamge = false;
    bool thisTurnEnemyTakeDamage = false;

    int enemyCountThisLevel;
    int nextStageWithEnemy;
    int spawnedEnemyCount = 0;
    bool canSpawnNextEnemy = true;

    bool firstMoveDone = false;
    bool isLevelEnded = false; //no mater how
    // Use this for initialization
    void Start()
    {
        lastStage = enemyControler.levelData.lastStage;
        turnTimeStartValue = turnTime;
        updateHpBar();
        loadEnemyControler();
    }

    // Update is called once per frame
    void Update()
    {
        if ((firstMoveDone|| Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightArrow))&&isLevelEnded==false)
        {
            firstMoveDone = true;
            timer();

            if (isAlive)
            {
                if (actualStage + 1 == nextStageWithEnemy && canSpawnNextEnemy)
                {
                    actualEnemy = enemyControler.spawnEnemy();
                    canSpawnNextEnemy = false;
                }

                desidePlayerMove();
                if (actualEnemy != null)
                {
                    actualEnemy.Deside();
                    if (actualEnemy.isEnemyAtackingTihsTurn == true && enemyAttackedThisTurn == false)
                    {
                        thisTurnPlayerTakeDamge = true;
                        enemyAttackedThisTurn = true;
                    }
                }

                if (movedThisTurn || turnTime <= 0)
                {
                    //rozpatrz ruchy 
                    endTurn();
                    restartTimer();
                }
            }
        }
    }

    void desidePlayerMove() //wait for playr Move
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //move
            if (actualStage + 1 < nextStageWithEnemy)
            {
                move();
            }
            else
            {
                if (actualStage + 1 == lastStage)
                {
                    uIControler.activeWinPanel();
                    isLevelEnded = true;
                }
                else
                    thisTurnPlayerTakeDamge = true;
            }
            movedThisTurn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //dodge
            playerIsDodging = true;
            movedThisTurn = true;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //attack
            if (actualStage + 1 == nextStageWithEnemy)
            {
                thisTurnEnemyTakeDamage = true;
            }
            movedThisTurn = true;
        }
    }
    void restartTimer()
    {
        turnTime = turnTimeStartValue;
    }
    void move()
    {
        BGChange.moveBackGroud();
        actualStage++;
    }
    void playerEndTurn() //sumig up player turn
    {
        if (thisTurnPlayerTakeDamge && playerIsDodging == false && actualEnemy != null)
        {
            takeDamage(actualEnemy.damage);
        }
        if (hp <= 0)
        {
            isAlive = false;
            uIControler.activeLosePanel();
            isLevelEnded = true;
        }
        if (isAlive)
        {
            movedThisTurn = false;
            playerIsDodging = false;
            thisTurnPlayerTakeDamge = false;
        }
        updateHpBar();
    }
    void endTurn() //suming up turn
    {
        playerEndTurn();
        if (actualEnemy != null)
        {
            if (thisTurnEnemyTakeDamage)
            {
                actualEnemy.takeDamege(damage);
                thisTurnEnemyTakeDamage = false;
            }
            actualEnemy.endTurn();
            enemyAttackedThisTurn = false;

            if (actualEnemy.isEnemyAlive == false)
            {
                Destroy(actualEnemy.gameObject);
                loadNextEnemyStage();
                actualEnemy = null;
                if (nextStageWithEnemy != lastStage)
                {
                    canSpawnNextEnemy = true;
                }
            }
        }

        if (isAlive == false)
        {
            //show end game screen
            Debug.Log("nie żyjez");
        }
    }
    void timer()  //count time and update timeBar
    {
        if (turnTime > 0)
        {
            turnTime -= Time.deltaTime;
        }
        updateTimeBar();
    }
    void updateTimeBar() //update timeBar
    {
        TimeBar.fillAmount = turnTime / turnTimeStartValue;
    }
    void updateHpBar() //update HpBar
    {
        HpBar.fillAmount = hp / 10f;
    }
    void loadEnemyControler()
    {
        enemyCountThisLevel = enemyControler.levelData.enemyCount;
        nextStageWithEnemy = enemyControler.stagesWithEnemy[spawnedEnemyCount];

    }
    void loadNextEnemyStage()
    {
        spawnedEnemyCount++;
        if (spawnedEnemyCount < enemyCountThisLevel)
        {
            nextStageWithEnemy = enemyControler.stagesWithEnemy[spawnedEnemyCount];
        }
        else
        {
            Debug.Log("pokonałeś wszystkich");
            canSpawnNextEnemy = false;
            nextStageWithEnemy = lastStage;
        }
    }
    void takeDamage(int damage)
    {
        hp -= damage;
    }


}