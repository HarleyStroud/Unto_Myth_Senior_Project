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
    public Text goldDisplay;
    public TopHUDController topHUDController;
    public GameObject cardSelector;
    public GameObject endTurnBtn;

    public GameObject shieldIntention;
    public GameObject attackIntention;

    public GameObject playerStation;

    public BattleState state;

    Unit playerUnit;
    EnemyAI enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public GameObject enemyHUDObject;

    private GameObject playerGo;
    private GameObject enemyGo;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<EnemyAI>();

        setEnemyIntent();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        playerUnit.currentFaith = playerUnit.maxFaith;

        playerHUD.SetMaxFaith(playerUnit);
        playerHUD.SetCurrentFaith(playerUnit);

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
        playerHUD.SetCurrentFaith(playerUnit);
        yield return new WaitForSeconds(1.5f);

        if(isDead)
        {
            turnText.text = "VICTORY!";

            Destroy(enemyGo);
            Destroy(enemyHUDObject);

            playerUnit.GainGold(10);
            topHUDController.DisplayGold(playerUnit);

            playerStation.SetActive(false);
            cardSelector.SetActive(true);
            endTurnBtn.SetActive(false);


            turnSystem.isGameOver = true;
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
        playerHUD.SetCurrentFaith(playerUnit);

        yield return new WaitForSeconds(1.5f);
    }
        
    void PlayerTurn()
    {}

    public void EnemyTurn()
    {
        playerUnit.currentFaith = playerUnit.maxFaith;
        playerHUD.SetCurrentFaith(playerUnit);

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
            shieldIntention.SetActive(false);
            attackIntention.SetActive(true);
        }
        else if (randomIndex == 1)
        {
            enemyUnit.intention = "Defend";
            shieldIntention.SetActive(true);
            attackIntention.SetActive(false);

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
