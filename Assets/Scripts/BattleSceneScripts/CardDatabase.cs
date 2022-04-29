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
        cardList.Add(new Card(2, "Swift Spear", 2, 5, "Deal 10 Damage and gain 5 Armor", Resources.Load<Sprite>("3")));
        cardList.Add(new Card(3, "Tortoise Shield", 2, 5, "Gain 15 block", Resources.Load<Sprite>("4")));
        cardList.Add(new Card(4, "Sweep The Battle Line", 2, 5, "Deal 10 damage to all enemies", Resources.Load<Sprite>("5")));
    }

}
