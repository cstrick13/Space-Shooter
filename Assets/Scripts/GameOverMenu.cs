using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   [SerializeField] GameObject gameOver;
    public void Pause(){
        gameOver.SetActive(true);
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