using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneCounter : MonoBehaviour
{
    private bool started = false;
    public float startTime;
    private float elapsed;
    public string SceneName;
     
     void Start(){

     }

    public void Update(){
         elapsed = Time.time - startTime;
        print(elapsed);
        if (elapsed > 15f){
            SceneManager.LoadSceneAsync(SceneName);
        }
        print("test");
    }

}