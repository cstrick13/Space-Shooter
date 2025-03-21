using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneSoundManager : MonoBehaviour
{
    
    
    public AudioClip clipBullet;
    public AudioClip clipExpo;
    public AudioClip clipHurt;
    public AudioClip clipTorpedo;
    //public AudioClip clipTorpExplode;
    //public AudioClip clipEnemDie;

    private AudioSource SFX;

    public void Start(){
        SFX = GetComponent<AudioSource>();
    }

    // Make it so that only one instance of the UI sounds can be heard.
    void Awake()
    {
        if (FindObjectsOfType(typeof(SceneOneSoundManager)).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void FireBullet()
    {
        SFX.clip = clipBullet;
        SFX.PlayOneShot(clipBullet, 1);
    }

    public void PlayerDie()
    {
        SFX.clip = clipExpo;
        SFX.PlayOneShot(clipExpo, 1);
    }
    public void PlayerHurt()
    {
        SFX.clip = clipHurt;
        SFX.PlayOneShot(clipHurt, 1);
    }
    public void FireTorpedo()
    {
        SFX.clip = clipTorpedo;
        SFX.PlayOneShot(clipTorpedo, 1);
    }
}
