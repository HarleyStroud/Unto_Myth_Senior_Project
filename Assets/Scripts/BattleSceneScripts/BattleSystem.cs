using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour

    
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    public TurnSystem turnSystem;
    public Text turnText;

    public BattleState state;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }


    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        setEnemyIntent();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }


    public void playerAttack()
    {
        StartCoroutine(PlayerAttack());
    }


    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(5);

        enemyHUD.SetHP(enemyUnit);
        yield return new WaitForSeconds(1.5f);

        if(isDead)
        {
            turnText.text = "VICTORY!";
            turnSystem.isGameOver = true;
        }
        else
        {

        }
    }

    public void playerBlock()
    {
        StartCoroutine(PlayerBlock());
    }


    IEnumerator PlayerBlock()
    {
        playerUnit.GainBlock(5f);
        playerHUD.setBlock(playerUnit);

        yield return new WaitForSeconds(1.5f);

    }
        
    void PlayerTurn()
    {
        
    }

    public void EnemyTurn()
    {
        if(enemyUnit.intention == "Attack")
        {
            StartCoroutine(EnemyAttack());
        }
        else if(enemyUnit.intention == "Defend")
        {
            StartCoroutine(EnemyDefend());
        }
       
    }


    public void setEnemyIntent()
    {
        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            enemyUnit.intention = "Attack";
        }
        else if (randomIndex == 1)
        {
            enemyUnit.intention = "Defend";
        }
        enemyHUD.SetEnemyIntention(enemyUnit);
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1.5f);

        playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit);
        turnSystem.endEnemyTurn();
    }

    IEnumerator EnemyDefend()
    {
        yield return new WaitForSeconds(1.5f);

        enemyUnit.GainBlock(5);
        enemyHUD.SetEnemyIntention(enemyUnit);
        enemyHUD.setBlock(enemyUnit);
        turnSystem.endEnemyTurn();
    }

}
