using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectScript : MonoBehaviour
{
    public GameObject cardSelect;
    public GameObject PlayerStation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardSelectionInactive()
	{
        cardSelect.SetActive(false);
        PlayerStation.SetActive(true);
	}
}
