using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(1, "Attack", 0, 0, "", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(2, "Defend", 0, 0, "", Resources.Load<Sprite>("1")));
    }

}
