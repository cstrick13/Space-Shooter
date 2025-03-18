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
    public GameObject shooterPrefab;
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
            Destroy(bullet, 2f);
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            var torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = spawnPt.position;
            Destroy(torpedo, 2f);
        }
        // DEV TOOLS/CHEATS, TO BE DELETED IN FINAL VERSION!
        if (DEBUG == true)
        {
            if (input.DevSpawnDrone.WasPressedThisFrame())
            {
                var droneEnemy = Instantiate(dronePrefab);
                droneEnemy.transform.position = enemySpawn.position;
            }
            if (input.DevSpawnEnemyShooter.WasPressedThisFrame())
            {
                var shootingEnemy = Instantiate(shooterPrefab);
                shootingEnemy.transform.position = enemySpawn.position;
            }
        }
        //DEV TOOLS ABOVE

        transform.Translate (Vector3.up * moveSpeed * Time.deltaTime * input.FlyUp.ReadValue<float>());
        transform.Translate (Vector3.down * moveSpeed * Time.deltaTime * input.FlyDown.ReadValue<float>());
        transform.Translate (Vector3.left * moveSpeed * Time.deltaTime * input.FlyLeft.ReadValue<float>());
        transform.Translate (Vector3.right * moveSpeed * Time.deltaTime * input.FlyRight.ReadValue<float>());
    }
}
