using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject Card;
    public GameObject PlayerArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Update()
    {
        /*PlayerArea = GameObject.Find("PlayerArea");
        Card.transform.SetParent(PlayerArea.transform);
        Card.transform.localScale = Vector3.one;
        Card.transform.position = new Vector3(transform.position.x, transform.position.y - 48);
        Card.transform.eulerAngles = new Vector3(25, 0, 0);*/
    }
    public void OnClick()
    {
        for(var i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(PlayerArea.transform, false);
        }
        
    }
}
