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
    public Text maxFaithText;
    public Text currentFaithText;

    void Update()
    {

    }

    // Initialize HUD values for player and enemy health.
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


    // Enable block icon on units health bar and update the units armor.
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

    public void SetMaxFaith(Unit unit)
    {
        maxFaithText.text = " / " +  unit.maxFaith.ToString();
    }

    public void SetCurrentFaith(Unit unit)
    {
       currentFaithText.text = unit.currentFaith.ToString();
    }


    public void SetEnemyIntention(EnemyAI enemy)
    {
        if(enemy.intention == "Attack")
        {
            enemyIntention.text = enemy.damage.ToString();
        }
        else
		{
            // Hardcoding block value for presentation. Will change later.
            enemyIntention.text = 5.ToString();
        }
       
    }

 
}
