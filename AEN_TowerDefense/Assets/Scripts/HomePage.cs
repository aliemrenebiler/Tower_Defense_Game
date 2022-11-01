using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public GameObject homePageUI;
    public GameObject gameUI;

    public void StartTheGame()
    {
        GameManager.gameStarted = true;
        homePageUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    
}
