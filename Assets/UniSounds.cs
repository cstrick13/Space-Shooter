using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniSounds : MonoBehaviour
{
    public AudioClip clipStart;
    public AudioClip clipOptions;
    public AudioClip clipChangeOp;
    public AudioClip clipQuit;
    public AudioClip clipBack;

    private AudioSource Button;


    // Make it so that only one instance of the UI sounds can be heard.
    void Awake()
    {
        if (FindObjectsOfType(typeof(UniSounds)).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartButton()
    {
        Button = GetComponent<AudioSource>();
        Button.clip = clipStart;
        Button.Play();
    }


}
