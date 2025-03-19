using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public Transform spawnPt;

    //Dev objects
    public GameObject shooterPrefab;

    public bool DEBUG;

    public int lives = 6;
    public Image[] livesUI;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
            Destroy(bullet, 2f);
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            var torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = spawnPt.position;
            Destroy(torpedo, 2f);
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
