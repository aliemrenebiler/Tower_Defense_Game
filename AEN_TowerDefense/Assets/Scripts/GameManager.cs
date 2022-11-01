using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public static bool gameStarted;

    public GameObject homePageUI;
    public GameObject gameUI;
    public GameObject gameOverUI;

    void Start()
    {
        gameStarted = false;
        gameIsOver = false;

        homePageUI.SetActive(true);
        gameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if(gameStarted && !gameIsOver && Input.GetKey("x"))
        {
            EndGame();
        }
        if(!gameIsOver && PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        
        homePageUI.SetActive(false);
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }
}
