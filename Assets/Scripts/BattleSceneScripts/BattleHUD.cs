using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Image HealthBar;
    public Text healthText;
    public Text enemyIntention;
    public Text block;
    public GameObject shield;



    void Update()
    {
        if(!TurnSystem.isPlayerTurn)
        {
            
        }
    }


    public void SetHUD(Unit unit)
    {
        if (unit.armor <= 0)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
        }
        SetEnemyIntention(unit);
        HealthBar.fillAmount = unit.currentHP / unit.maxHP;
        healthText.text = unit.currentHP.ToString();
    }

    public void SetHP(Unit unit)
    {
        setBlock(unit);

        if(unit.armor <= 0)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
        }
        healthText.text = unit.currentHP.ToString();
        HealthBar.fillAmount = unit.currentHP / unit.maxHP;
    }

    public void setBlock(Unit unit)
    {
        if (unit.armor <= 0)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
        }
        block.text = unit.armor.ToString();
    }


    public void SetEnemyIntention(Unit unit)
    {
        if (unit.unitType == "Enemy")
        {
            enemyIntention.text = unit.intention + "( " + unit.damage + " )";
        }

    }

 
}
