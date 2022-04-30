using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsScreen;
    public GameObject splashScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableSplashScreen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(string sceneName)
    {
        Debug.Log("Start Game button pressed.");
        SceneManager.LoadScene(sceneName);
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


    IEnumerator DisableSplashScreen()
    {
        yield return new WaitForSeconds(2f);
        splashScreen.SetActive(false);
        
    }
}
