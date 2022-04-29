using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int totalDeckSize;
    public static int deckSize;
    
    public int cardDrawPerTurn;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject CardToHand;
    public GameObject PlayerArea;

    public GameObject[] Clones;

    // Start is called before the first frame update
    void Start()
    {
        initDeck();

        cardDrawPerTurn = 5;

        StartCoroutine(Draw(cardDrawPerTurn));
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if(deckSize < 4)
        {
            cardInDeck4.SetActive(false);
        }
        if(deckSize < 3)
        {
            cardInDeck3.SetActive(false);
        }
        if(deckSize < 2)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck1.SetActive(false);
        }

        if(TurnSystem.startTurn)
        {
            StartCoroutine(Draw(cardDrawPerTurn));
            TurnSystem.startTurn = false;
        }
    }


    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        GameObject cardBackClone = Instantiate(CardBack, transform.position, transform.rotation);
        cardBackClone.tag = "Clone";
    
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    public void initDeck()
    {
        int x = 0;
        totalDeckSize = 8;
        deckSize = totalDeckSize;

        deck[0] = CardDatabase.cardList[0];
        deck[1] = CardDatabase.cardList[0];
        deck[2] = CardDatabase.cardList[0];
        deck[3] = CardDatabase.cardList[0];

        deck[4] = CardDatabase.cardList[1];
        deck[5] = CardDatabase.cardList[1];
        deck[6] = CardDatabase.cardList[1];
        deck[7] = CardDatabase.cardList[1];

        Shuffle();

        Debug.Log("initDeck ---  totalDeckSize: " + totalDeckSize + "  ,  deckSize: " + deckSize);
    }

   

    IEnumerator Draw(int numOfCards)
    {
        for(int i =0; i < numOfCards; i++)
        {

            if(deckSize == 0)
            {
                ResetDeck();
            }

            yield return new WaitForSeconds(0.75f);
            Instantiate(CardToHand, transform.position, transform.rotation);

            Debug.Log("Draw " + numOfCards + " ---  Drawing card :  " + i  + "  ,  cards left: " + deckSize);
        }
    }


    public void ResetDeck()
    {
        deckSize = totalDeckSize;
        GameObject Graveyard = GameObject.Find("Graveyard");

        foreach(Transform child in Graveyard.transform)
        {
            Destroy(child.gameObject);
        }

        cardInDeck1.SetActive(true);
        cardInDeck2.SetActive(true);
        cardInDeck3.SetActive(true);
        cardInDeck4.SetActive(true);
    }
}
