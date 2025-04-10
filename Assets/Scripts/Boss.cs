using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{

    public float entrySpeed = 200f;
    public float stopX = 2f;
    private bool hasStopped = false;

    public GameObject enemyBulletPrefab;
    public Transform[] spawnPoints;
    public float shootInterval = 0.5f;
    private float shootTimer;

    public int maxLives = 50;
    private int currentLives;

    public ParticleSystem smallExplosionPrefab;
    public ParticleSystem explosionPrefab;

    public AudioClip explosionAudio;

    private AudioSource audioSrc;
    public GameObject target;
    private bool isVisible = false;
    Victory MyScript;

    void Start()
    {
        currentLives = maxLives;
        Vector3 startPos = new Vector3(12, Random.Range(-3f, 2f), 0);
        transform.position = startPos;
        target = GameObject.FindWithTag("Player");
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * entrySpeed);
        GameObject obj = GameObject.Find("Game");
        MyScript = obj.GetComponent<Victory>();
    }

     void Update()
    {
        if (!isVisible) return;

        if (!hasStopped && transform.position.x <= stopX)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hasStopped = true;
        }

        if (hasStopped)
        {
            //Find the point x amount in front of players current position to move towards.
            Vector3 align = new Vector3((stopX), target.transform.position.y, target.transform.position.z);
            if (target.transform.position != this.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, align, 1.25f * Time.deltaTime);
            }
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                ShootCurrentPhase();
                shootTimer = shootInterval;
            }
        }
    }
    void ShootCurrentPhase()
    {
        if (currentLives > 34)
        {
            FireFrom(spawnPoints[0]);
        }
        else if (currentLives > 17)
        {
            FireFrom(spawnPoints[0]);
            FireFrom(spawnPoints[1]);
        }
        else
        {
            foreach (Transform spawn in spawnPoints)
                FireFrom(spawn);
        }
    }

    void FireFrom(Transform spawn)
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, spawn.position, Quaternion.identity);
        Destroy(bullet, 3f);
    }
    void OnTriggerEnter2D(Collider2D collision){
    int damage = 0;

    if (collision.CompareTag("Bullet"))
        damage = 2;
    else if (collision.CompareTag("HeetSeeker"))
        damage = 1;
    else if (collision.CompareTag("Torpedo"))
        damage = 4;

    if (damage > 0)
    {
        currentLives -= damage;
        Destroy(collision.gameObject);
        Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);

        if (currentLives <= 0)
            Die();

    }
    else if (collision.CompareTag("ScoreBoundary"))
    {
        Game.Instance.SubtractToScore(1001);
        Destroy(gameObject);
    }
}


    void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionAudio, transform.position);
        Game.Instance.AddToScore(5000);
        Destroy(gameObject);
        MyScript.VictoryScreen();
    }

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
