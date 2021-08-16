using UnityEngine;
using UnityEngine.Playables;

public class StoryPanel : MonoBehaviour
{
    public PlayableDirector director;
    private bool fix = false;
    public GameObject storyPanel;

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing && !fix)
        {
            fix = true;
            storyPanel.SetActive(false);
        }
    }
}
