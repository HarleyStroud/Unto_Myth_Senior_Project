using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private FlashScript flashEffect;

    public string unitType;
    public string unitName;

    public float damage;

    public float maxHP;
    public float currentHP;

    public float armor;

    public int gold;

    public int maxFaith;
    public int currentFaith;


    private void Awake()
    {
        flashEffect = gameObject.GetComponent<FlashScript>();
    }

    private void Start()
    {
        
    }


    public bool TakeDamage(float dmg)
    {
        flashEffect.Flash();
        float damageAfterArmor = dmg;
        if(armor > 0)
        {
            if(dmg > armor)
            {
                dmg = dmg - armor;
                armor = 0;

                if (dmg > 0)
                {
                    currentHP -= dmg;
                }
            }
            else
            {
                armor = armor - dmg;
            }
        }
        else
        {
            currentHP -= dmg;
        }

        if(currentHP <= 0)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }

    public void GainBlock(float block)
    {
        armor += block;
    }


    public void GainGold(int gold)
	{
       this.gold = gold;
	}

    public int GetGold()
	{
        return this.gold;
	}
}
