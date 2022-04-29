using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopHUDController : MonoBehaviour
{
    public Text GoldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DisplayGold(Unit unit)
	{
        GoldText.text = unit.GetGold().ToString();
	}
}
