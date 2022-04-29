using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class ThisCard : MonoBehaviour
{
    public GameObject battleSystem;
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject PlayerArea;

    public int numberOfCardsInDeck;


    public GameObject Graveyard;
    public bool inGraveyard;

    public GameObject dropZone;
    public GameObject player;
    public Unit playerUnit;



    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;

        player = GameObject.Find("Player(Clone)");
        playerUnit = (Unit)player.GetComponent("Unit");
        dropZone = GameObject.Find("Drop Zone");
    }


    // Update is called once per frame
    void Update()
    {
        PlayerArea = GameObject.Find("PlayerArea");
        battleSystem = GameObject.Find("BattleSystem");
        

        if (this.transform.parent == PlayerArea.transform.parent)
        {
            cardBack = false;
        }


        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        descriptionText.text = "" + cardDescription;

        thatImage.sprite = thisSprite;

        staticCardBack = cardBack;
        
        if(this.tag == "Clone")
        {
            if(PlayerDeck.deckSize != 0)
            {
                thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
                numberOfCardsInDeck -= 1;
                PlayerDeck.deckSize -= 1;
                cardBack = false;
                this.tag = "First";
            }
        } 

        if(playerUnit.currentFaith >= cost)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {

            gameObject.GetComponent<Draggable>().enabled = false;
        }
    }


    public void PlayCard()
    {
        BattleSystem battle = (BattleSystem)battleSystem.GetComponent("BattleSystem");
        
        playerUnit.currentFaith -= cost;

        if (cardName == "Attack")
        {
            battle.playerAttack();
        }
        else if (cardName == "Defend")
        {
            battle.playerBlock();
        }
    }

    public void Discard()
    {
        StartCoroutine(MoveToGraveyard());
    }

    IEnumerator MoveToGraveyard()
    {
        yield return new WaitForSeconds(0.5f);
        Graveyard = GameObject.Find("Graveyard");
        Draggable d = GetComponent<Draggable>();
        d.parentToReturnTo = Graveyard.transform;
        d.enabled = false;

        this.transform.SetParent(Graveyard.transform);
        inGraveyard = true;
    }
}
