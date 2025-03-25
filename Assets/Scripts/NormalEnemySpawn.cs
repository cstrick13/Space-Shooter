using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private float lives = 1;

     public ParticleSystem smallExplosionPrefab;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(100f, 500f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }void OnTriggerEnter2D(Collider2D collision){
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
            Game.Instance.AddToScore(60);
            Destroy(gameObject);
        }
        return;
    }

    if (collision.CompareTag("ScoreBoundary"))
    {
        Game.Instance.SubtractToScore(801);
        Destroy(gameObject);
    }
}
    
}
