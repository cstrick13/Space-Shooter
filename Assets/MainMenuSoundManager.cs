using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundManager : MonoBehaviour
{
    public AudioClip clipStart;
    public AudioClip clipOptions;
    public AudioClip clipChangeOp;
    public AudioClip clipQuit;
    public AudioClip clipBack;

    private AudioSource Button;

    public void Start(){
        Button = GetComponent<AudioSource>();
    }

    // Make it so that only one instance of the UI sounds can be heard.
    void Awake()
    {
        if (FindObjectsOfType(typeof(MainMenuSoundManager)).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // The start button calls this, which plays the sound without being cut off
    // when switching scenes.
    public void StartButton()
    {
        Button.clip = clipStart;
        Button.Play();
    }

    public void OptionsMenu()
    {
        Button.clip = clipOptions;
        Button.Play();
    }

    public void OptionsBack()
    {
        Button.clip = clipBack;
        Button.Play();
    }

    public void QuitButton()
    {
        Button.clip = clipQuit;
        Button.Play();
    }
}
