using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour{
    public float moveSpeed;
    public GameObject enemybulletPrefab;
    public Transform spawnPt;
    
    private float shootInterval = 2f; 
    private float shootTimer = 0f;
    
    private bool isVisible = false;

    private float lives = 4;
    public ParticleSystem smallExplosionPrefab;

    public ParticleSystem explosionPrefab;

    public AudioClip smallexplosionAudio;
    private AudioSource audioSrc;

    void Start()
    {
        // Optionally set initial position here if needed:
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(25f, 75f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    void Update()
    {
        // not visibile do nothing
        if (!isVisible)
            return;
        
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            print("Shoot Timer: " + shootTimer);
            print("Shoot Interval:" + shootInterval);
            Shoot();
            shootTimer = 0;
        }
    }

      void OnTriggerEnter2D(Collider2D collision){
        int damage = 0;
        if (collision.CompareTag("Bullet")){
            damage = 2;
        }else if (collision.CompareTag("HeetSeeker")){
             damage = 1;
        }else if (collision.CompareTag("Torpedo")){
            damage = 4;
        }
        if (damage > 0){
        lives -= damage;
        Destroy(collision.gameObject);

        if (lives <= 0)
        {
             Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);
              AudioSource.PlayClipAtPoint(smallexplosionAudio, transform.position);
            Game.Instance.AddToScore(400);
            Destroy(gameObject);
        }
        return;
    }

    if (collision.CompareTag("ScoreBoundary"))
    {
        Game.Instance.SubtractToScore(300);
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
