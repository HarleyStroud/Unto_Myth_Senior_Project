using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject it;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("PlayerArea");
        it.transform.SetParent(Hand.transform);
        it.transform.localScale = Vector3.one;
        //it.transform.position = new Vector3(transform.position.x, transform.position.y - 48);
        it.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
