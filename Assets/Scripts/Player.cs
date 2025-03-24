using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public GameObject seekerPrefab;
    public Transform spawnPt;

    public bool hasSeeker = false;
    public int lives = 6;
    public Image[] livesUI;

    private float delay;
    public ParticleSystem smallExplosionPrefab;

    public ParticleSystem explosionPrefab;

    public float explosionDuration = 1.0f;

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
        if (input.ShootSeeker.WasPressedThisFrame() && hasSeeker == true)
        {
            var seeker = Instantiate(seekerPrefab);
            seeker.transform.position = spawnPt.position;
            //DEV: May not want to destoy with timer due to nature of projectile
            Destroy(seeker, 10f);
        }
        // DEV TOOLS/CHEATS, TO BE DELETED IN FINAL VERSION!
        Game game = GameObject.FindWithTag("Game").GetComponent<Game>();
        if (game.DEBUG == true)
        {
            if (input.DevSpawnDrone.WasPressedThisFrame())
            {
                var droneEnemy = Instantiate(game.droneEnemyPrefab);
                droneEnemy.transform.position = game.devSpawn.position;
            }
            if (input.DevSpawnCrateSeeker.WasPressedThisFrame())
            {
                var seekerCrate = Instantiate(game.seekerCratePrefab);
                seekerCrate.transform.position = game.devSpawn.position;
            }
        }
        
        //DEV TOOLS/

        float up    = input.FlyUp.ReadValue<float>();
        float down  = input.FlyDown.ReadValue<float>();
        float left  = input.FlyLeft.ReadValue<float>();
        float right = input.FlyRight.ReadValue<float>();
        // Move exactly as before
        transform.Translate(Vector3.up    * moveSpeed * Time.deltaTime * up);
        transform.Translate(Vector3.down  * moveSpeed * Time.deltaTime * down);
        transform.Translate(Vector3.left  * moveSpeed * Time.deltaTime * left);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * right);
        // Play flame when moving (up/down/right) — stop when moving
        //if ((up > 0f || down > 0f || right > 0f) && left == 0f){
             //flameEffect.Play();
        //}else{
            //flameEffect.Stop();
        //}
    }

    void OnTriggerEnter2D(Collider2D collision){
        // Handle enemy collision to destroy the enemy object
        // we can instantiate an animation of an explosion  here whenever the player collides with an explosion and also can do the same by attaching a collision script similar to this on a bullet
         Debug.Log("Collision with: " + collision.gameObject.name + " Tag: " + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy" || collision.CompareTag("Boss") ){
                Debug.Log("Life lost due to collision with: " + collision.gameObject.name);
                Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);
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
                Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
                // where we can call the game over screen
            }
        }
    }

      void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("OnCollisionEnter2D");
    }

}
