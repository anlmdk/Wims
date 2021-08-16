using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource sound;
    public bool soundCheck;
    public Button soundButton;
    // Start is called before the first frame update
    void Start()
    {
        sound.Play();
        soundCheck = true;
        soundButton.GetComponent<Button>();
    }
    public void ToggleOnOff()
    {
        if (soundCheck ^= true)
        {
            sound.Play();
        }
        else
        {
            sound.Pause();
        }
    }
}
