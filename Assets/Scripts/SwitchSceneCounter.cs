using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneCounter : MonoBehaviour
{
    public GameObject background;         // Drag your “Background” GameObject here
    public GameObject particleSystemObj;  // Drag your Particle System GameObject here
    public float delaySeconds = 15f;

    private float startTime;

    void Start()
    {
        startTime = Time.time;

        // Make sure background starts disabled; particle stays enabled until the swap
        if (background != null) background.SetActive(false);
        if (particleSystemObj != null) particleSystemObj.SetActive(true);
    }

    void Update()
    {
        if (Time.time - startTime > delaySeconds)
        {
            if (background != null) background.SetActive(true);

            enabled = false;
        }
    }

}