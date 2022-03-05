using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;
    public static int deckSize;

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

        x = 0;
        deckSize = 40;

        for(int i =0; i < deckSize; i++)
        {
            x = Random.Range(0, 2);
            deck[i] = CardDatabase.cardList[x];
        }

        StartCoroutine(StartGame());
        
    }

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;

        if(deckSize < 20)
        {
            cardInDeck4.SetActive(false);
        }
        if(deckSize < 10)
        {
            cardInDeck3.SetActive(false);
        }
        if(deckSize < 5)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck1.SetActive(false);
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
/*        cardBackClone.SetActive(false);*/     
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


    


    IEnumerator StartGame()
    {
        for(int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }
}
