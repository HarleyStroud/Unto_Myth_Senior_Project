using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Start Game button pressed.");
    }

    public void OpenOptions()
    {
        Debug.Log("Open Options button pressed.");
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        Debug.Log("Close Options button pressed.");
        optionsScreen.SetActive(false);
    }


    public void QuitGame()
    {
        Debug.Log("Quit button pressed.");
        Application.Quit();
    }
}
