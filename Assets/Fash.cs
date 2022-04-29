using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fash : MonoBehaviour
{

    [SerializeField] private FlashScript flashEffect;
    [SerializeField] private KeyCode flashKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(flashKey))
        {
            flashEffect.Flash();
        }
    }
}
