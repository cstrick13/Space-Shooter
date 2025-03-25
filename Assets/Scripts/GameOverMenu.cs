using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   [SerializeField] GameObject gameOver;
   public AudioClip gameOverAudio;
   private AudioSource audioSrc;
    void Start() {
        audioSrc = GetComponent<AudioSource>();
     
    }

    public void GameOver(){
        gameOver.SetActive(true);
        Time.timeScale = 0;
        //StartCoroutine(MenuAppear());
        Camera.main.GetComponent<AudioSource>()?.Stop();
        audioSrc.clip = gameOverAudio;
        audioSrc.Play();
    }
    //IEnumerator MenuAppear(){
        //yield return new WaitForSeconds(1f);
        //gameOver.SetActive(true);
        //Time.timeScale = 0;
    //}
   
    public void Home(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}