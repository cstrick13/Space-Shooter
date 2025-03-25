using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VictoryScreen(){
        victoryScreen.SetActive(true);
        Time.timeScale = 0;
    } 

        public void Home(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
