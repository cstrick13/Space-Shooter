using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLives : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives = 6;
    public Image[] livesUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Enemy"){
            lives-=1;
            for(int i = 0; i< livesUI.Length;i++){
                if(i < lives){
                    livesUI[i].enabled = true;
                } else{
                    livesUI[i].enabled = false;
                }
            }
            if(lives <=0){
                Destroy(gameObject);
            }
        }
    }
}
