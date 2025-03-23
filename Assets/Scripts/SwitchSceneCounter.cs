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
    private bool alive = true;
     
     void Start(){

    }

    public void Update(){
        
        GameObject holderObject = GameObject.Find("Player");
        Player variableHolder = holderObject.GetComponent<Player>();
        int accessedVariable = variableHolder.lives;
        Debug.Log("Accessed Variable: " + accessedVariable);
        if(accessedVariable <= 0){
            alive = false;
        }
        
        elapsed = Time.timeSinceLevelLoad - startTime;
        print(elapsed);
        
        if (elapsed > 15f){
            if(alive){
                SceneManager.LoadSceneAsync(SceneName);
            }
        }
    }

}