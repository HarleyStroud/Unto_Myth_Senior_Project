using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "Attack", 1, 5, "Deal 5 Damage", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(1, "Defend", 1, 5, "Gain 5 Armor", Resources.Load<Sprite>("2")));
    }

}
