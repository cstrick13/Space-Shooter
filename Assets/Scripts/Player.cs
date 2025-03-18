using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public Transform spawnPt;

    //Dev objects
    public GameObject dronePrefab;
    public Transform enemySpawn;
    public bool DEBUG;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            var torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = spawnPt.position;
        }
        // DEV TOOLS/CHEATS, TO BE DELETED IN FINAL VERSION!
        if (DEBUG == true)
        {
            if (input.DevSpawnDrone.WasPressedThisFrame())
            {
                var droneEnemy = Instantiate(dronePrefab);
                droneEnemy.transform.position = enemySpawn.position;
            }
        }
        //DEV TOOLS/
        transform.Translate (Vector3.up * moveSpeed * Time.deltaTime * input.FlyUp.ReadValue<float>());
        transform.Translate (Vector3.down * moveSpeed * Time.deltaTime * input.FlyDown.ReadValue<float>());
        transform.Translate (Vector3.left * moveSpeed * Time.deltaTime * input.FlyLeft.ReadValue<float>());
        transform.Translate (Vector3.right * moveSpeed * Time.deltaTime * input.FlyRight.ReadValue<float>());
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy")
        {
        // Handle enemy collision to destroy the enemy object
        // we can instantiate an animation of an explosion  here whenever the player collides with an explosion and also can do the same by attaching a collision script similar to this on a bullet
            print("Player hit by enemy!");
            Destroy(collision.gameObject);
        }
    }

}
