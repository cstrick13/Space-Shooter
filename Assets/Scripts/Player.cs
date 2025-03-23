using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public GameObject seekerPrefab;
    public Transform spawnPt;

    public bool hasSeeker = false;
    public int lives = 6;
    private int bulletAmmo = 8;
    private int bulletMax = 8;
    private int torpedoAmmo = 3;
    private int torpedoMax = 3;
    private int seekerAmmo = 5;
    private int seekerMax = 5;

    public Image[] livesUI;

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            if (bulletAmmo > 0)
            {
                bulletAmmo--;
                //Could break music.
                StopAllCoroutines();
                var bullet = Instantiate(bulletPrefab);
                bullet.transform.position = spawnPt.position;
                Destroy(bullet, 2f);
            }
            else
            {
                //Delay the reload
                float timer = 1.5f;
                Coroutine reload = StartCoroutine(ReloadDelay(timer,0));
                StopCoroutine(reload);
            }
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            print(torpedoAmmo);
            if (torpedoAmmo > 0)
            {
                torpedoAmmo--;
                StopCoroutine(ReloadDelay(0f,0));
                var torpedo = Instantiate(torpedoPrefab);
                torpedo.transform.position = spawnPt.position;
                Destroy(torpedo, 2f);
            }
            else
            {
                //Delay the reload
                float timer = 2.5f;
                Coroutine reload = StartCoroutine(ReloadDelay(timer,1));
                StopCoroutine(reload);
            }
        }
        if (input.ShootSeeker.WasPressedThisFrame() && hasSeeker == true)
        {
            print(seekerAmmo);
            if (seekerAmmo > 0)
            {
                seekerAmmo--;
                var seeker = Instantiate(seekerPrefab);
                seeker.transform.position = spawnPt.position;
                Destroy(seeker, 10f);
            }
            else
            {
                //Delay the reload
                float timer = 3.5f;
                StartCoroutine(ReloadDelay(timer,2));
            }
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

        transform.Translate (Vector3.up * moveSpeed * Time.deltaTime * input.FlyUp.ReadValue<float>());
        transform.Translate (Vector3.down * moveSpeed * Time.deltaTime * input.FlyDown.ReadValue<float>());
        transform.Translate (Vector3.left * moveSpeed * Time.deltaTime * input.FlyLeft.ReadValue<float>());
        transform.Translate (Vector3.right * moveSpeed * Time.deltaTime * input.FlyRight.ReadValue<float>());
    }

    void OnTriggerEnter2D(Collider2D collision){
        // Handle enemy collision to destroy the enemy object
        // we can instantiate an animation of an explosion  here whenever the player collides with an explosion and also can do the same by attaching a collision script similar to this on a bullet
         //Debug.Log("Collision with: " + collision.gameObject.name + " Tag: " + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy"){
               // Debug.Log("Life lost due to collision with: " + collision.gameObject.name);
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

      void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("OnCollisionEnter2D");
    }

    private IEnumerator ReloadDelay(float timer,int ammoType)
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
