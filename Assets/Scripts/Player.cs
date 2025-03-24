using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public GameObject seekerPrefab;
    public Transform spawnPt;

    public bool hasSeeker = false;
    public int lives = 6;
    public Image[] livesUI;
    private int bulletAmmo = 8;
    private int bulletMax = 8;
    private int torpedoAmmo = 3;
    private int torpedoMax = 3;
    private int seekerAmmo = 5;
    private int seekerMax = 5;
    private Coroutine reloadDelay;

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
        if (input.ShootBullet.WasPressedThisFrame())
        {
            if (bulletAmmo > 0)
            {
                //Could break music
                StopAllCoroutines();
                bulletAmmo--;
                var bullet = Instantiate(bulletPrefab);
                bullet.transform.position = spawnPt.position;
                Destroy(bullet, 2f);
            }
            else
            {
                //Delay the reload
                float timer = 1.5f;
                reloadDelay = StartCoroutine(ReloadDelay(timer, 0));
            }
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            print(torpedoAmmo);
            if (torpedoAmmo > 0)
            {
                StopAllCoroutines();
                torpedoAmmo--;
                var torpedo = Instantiate(torpedoPrefab);
                torpedo.transform.position = spawnPt.position;
                Destroy(torpedo, 2f);
            }
            else
            {
                //Delay the reload
                float timer = 2.5f;
                reloadDelay = StartCoroutine(ReloadDelay(timer, 1));
            }
        }
        if (input.ShootSeeker.WasPressedThisFrame() && hasSeeker == true)
        {
            print(seekerAmmo);
            if (seekerAmmo > 0)
            {
                StopAllCoroutines();
                seekerAmmo--;
                var seeker = Instantiate(seekerPrefab);
                seeker.transform.position = spawnPt.position;
                Destroy(seeker, 10f);
            }
            else
            {
                //Delay the reload
                float timer = 3.5f;
                reloadDelay = StartCoroutine(ReloadDelay(timer, 2));
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
    private IEnumerator ReloadDelay(float timer, int ammoType)
    {

        yield return new WaitForSeconds(timer);
        //Bullets
        if (ammoType == 0)
        {
            bulletAmmo = bulletMax;
        }
        //Torpedos
        else if (ammoType == 1)
        {
            torpedoAmmo = torpedoMax;
        }
        //Seekers
        else if (ammoType == 2)
        {
            seekerAmmo = seekerMax;
        }
    }
}
