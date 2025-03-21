using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public GameObject seekerPrefab;
    public Transform spawnPt;

    public int lives = 6;
    public Image[] livesUI;
    public SceneOneSoundManager playsound;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            playsound.FireBullet();
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
            Destroy(bullet, 2f);
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            playsound.FireTorpedo();
            var torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = spawnPt.position;
            Destroy(torpedo, 2f);
        }
        if (input.ShootSeeker.WasPressedThisFrame())
        {
            var seeker = Instantiate(seekerPrefab);
            seeker.transform.position = spawnPt.position;
            //DEV: May not want to destoy with timer due to nature of projectile
            Destroy(seeker, 10f);
        }

        transform.Translate (Vector3.up * moveSpeed * Time.deltaTime * input.FlyUp.ReadValue<float>());
        transform.Translate (Vector3.down * moveSpeed * Time.deltaTime * input.FlyDown.ReadValue<float>());
        transform.Translate (Vector3.left * moveSpeed * Time.deltaTime * input.FlyLeft.ReadValue<float>());
        transform.Translate (Vector3.right * moveSpeed * Time.deltaTime * input.FlyRight.ReadValue<float>());
    }

    void OnTriggerEnter2D(Collider2D collision){
        // Handle enemy collision to destroy the enemy object
        // we can instantiate an animation of an explosion  here whenever the player collides with an explosion and also can do the same by attaching a collision script similar to this on a bullet
         Debug.Log("Collision with: " + collision.gameObject.name + " Tag: " + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy"){
                
                Debug.Log("Life lost due to collision with: " + collision.gameObject.name);
                Destroy(collision.gameObject);
                lives-=1;
                if(lives <=0){
                playsound.PlayerDie();
                Destroy(gameObject);
                } else{
                    playsound.PlayerHurt();
                }
                for(int i = 0; i< livesUI.Length;i++){
                    if(i < lives){
                    livesUI[i].enabled = true;
                    } else{
                        livesUI[i].enabled = false;
                        }
                }
            
        }
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }

}
