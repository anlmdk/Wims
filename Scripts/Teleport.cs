using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    LevelLoader level;
    [SerializeField]
    public int currectScene, nextScene;
    private void Start()
    {
        currectScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currectScene + 1;
        Debug.Log(currectScene);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        level.LoadLevel(nextScene);
    //    }
    //}
}
