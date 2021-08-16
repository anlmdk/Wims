using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool GameIsOver = false;
    public static GameOver instance;
    public GameObject gameOverMenuUI;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
        GameObject.Find("Player").GetComponent<PlayerManager>().enabled = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Start");
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = true;
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void PlayerDied()
    {
        gameOverMenuUI.name = "GameOverMenu";
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        GameObject.Find("Player").GetComponent<PlayerManager>().enabled = false;
    }
}
