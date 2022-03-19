using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public BattleSystem battleSystem;
    public Text turnText;
    public static bool isPlayerTurn;

    public int maxMana;
    public static int currentMana;

    public static bool startTurn;
    public bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        maxMana = 3;

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

        for(int i = PlayerArea.transform.childCount; i > 0; i--)
        {
            PlayerArea.transform.GetChild(i - 1).GetComponent<ThisCard>().Discard();
        }

      /*  foreach(Transform child in PlayerArea.transform)
        {
            child.GetComponent<ThisCard>().Discard();
            Debug.Log("Cards in hand");
        }*/
        //GameObject[] cards;





        isPlayerTurn = false;

        battleSystem.EnemyTurn();
    }

    public void endEnemyTurn()
    {
        battleSystem.setEnemyIntent();
        isPlayerTurn = true;
        currentMana = maxMana;

        startTurn = true;

    }
}
