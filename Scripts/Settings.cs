using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;
    public static bool gameIsPaused = false;
    private void Start()
    {
        if(Time.timeScale == 0)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GameObject.Find("Player").GetComponent<PlayerManager>().enabled = true;
    }
    public void Pause()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        GameObject.Find("Player").GetComponent<PlayerManager>().enabled = false;
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
