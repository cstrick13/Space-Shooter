using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneCounter : MonoBehaviour
{
    public GameObject background;         // First background
    public GameObject background2;        // Second background
    public GameObject particleSystemObj;  // Particle System GameObject
    public float delaySeconds = 23.4f;      // Delay for first background activation
    public float delaySeconds2 = 40f;       // Delay for second background activation

    private float startTime;

    void Start()
    {
        startTime = Time.time;

        // Ensure both backgrounds start disabled; particle system stays enabled until the swap
        if (background != null) background.SetActive(false);
        if (background2 != null) background2.SetActive(false);
        if (particleSystemObj != null) particleSystemObj.SetActive(true);
    }

    void Update()
    {
        // Activate the first background after delaySeconds seconds.
        if (Time.time - startTime > delaySeconds && background != null && !background.activeSelf)
        {
            background.SetActive(true);
        }

        // After delaySeconds2 seconds, switch to the second background.
        if (Time.time - startTime > delaySeconds2)
        {
            if (background != null) background.SetActive(false);
            if (background2 != null) background2.SetActive(true);
            // Optionally disable this script if no further updates are needed.
            enabled = false;
        }
    }
}
