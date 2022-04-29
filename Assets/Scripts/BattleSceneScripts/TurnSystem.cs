using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public BattleSystem battleSystem;
    public Text turnText;
    public static bool isPlayerTurn;
    public static int currentMana;

    public static bool startTurn;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;

        startTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            if (isPlayerTurn)
            {
                turnText.text = "Your turn";
            }
            else
            {
                turnText.text = "Enemy turn";
            }
        }
    }

    public void endPlayerTurn()
    { 
        GameObject PlayerArea = GameObject.Find("PlayerArea");

        // Discard all cards currently in the players hand.
        for(int i = PlayerArea.transform.childCount; i > 0; i--)
        {
            PlayerArea.transform.GetChild(i - 1).GetComponent<ThisCard>().Discard();
        }

        isPlayerTurn = false;

        battleSystem.EnemyTurn();
    }

    public void endEnemyTurn()
    {
        battleSystem.setEnemyIntent();
        isPlayerTurn = true;

        startTurn = true;
    }
}
