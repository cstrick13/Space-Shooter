using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour{
    public float moveSpeed;
    public GameObject enemybulletPrefab;
    public Transform spawnPt;
    
    public float shootInterval = .5f; 
    private float shootTimer = 0f;
    
    private bool isVisible = false;

    private float lives = 6;

    void Start()
    {
        // Optionally set initial position here if needed:
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(100f, 500f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    void Update()
    {
        // not visibile do nothing
        if (!isVisible)
            return;
        

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

      void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Bullet"){
            lives-=1;
            Destroy(collision.gameObject);
            if (lives < 0){
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Game.Instance.AddToScore(2000 + 1);
            }
        }
         if (collision.gameObject.tag == "ScoreBoundary"){
                Game.Instance.SubtractToScore(1000 + 1);
                Destroy(gameObject);
            }
        }

    void Shoot()
    {
        var bullet = Instantiate(enemybulletPrefab);
        bullet.transform.position = spawnPt.position;
        Destroy(bullet, 2f);
    }

    // This is called when the renderer becomes visible to any camera.
    void OnBecameVisible()
    {
        isVisible = true;
    }

    //Stop shooting when it is no longer visible.
    void OnBecameInvisible()
    {
        isVisible = false;
    }
    
}
