using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int damage;
    int Hp;
    int index = 0;
    public bool isEnemyAlive = true;
    public bool isEnemyAtackingTihsTurn = false;
    int[] attackPattern;
    public Image hpBar;
    public Sprite wulf;

    public void Deside()
    {
        if (attackPattern[index] == 1)
        {
            //attack
            isEnemyAtackingTihsTurn = true;
            GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (attackPattern[index] == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    public void endTurn()
    {
        if (Hp <= 0)
        {
            isEnemyAlive = false;
        }
        if (isEnemyAlive)
        {
            index++;
            if (index > attackPattern.Length - 1)
            {
                index = 0;
            }
            isEnemyAtackingTihsTurn = false;
        }
        updateHpBar();
    }
    public void takeDamege(int Damage)
    {
        Hp -= damage;
    }
    public void updateHpBar()
    {
        hpBar.fillAmount = Hp / 10f;
    }
    public void transmutateTo(string name)
    {
        switch (name)
        {
            case "Draug":
                Hp = 2;
                damage = 1;
                attackPattern = new int[] { 0, 1, 0 };
                break;
            case "Wolf":
                Hp = 1;
                damage = 2;
                attackPattern = new int[] { 1, 0 };
                GetComponent<SpriteRenderer>().sprite = wulf;
                break;
            default:
                transmutateTo("Draug");
                Debug.LogWarning("Spawned by defoult");
                break;
        }
    }
}