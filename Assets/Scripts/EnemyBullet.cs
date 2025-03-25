using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    private float lives = 5;

    public ParticleSystem smallExplosionPrefab;
    public AudioClip smallexplosionAudio;
    private AudioSource audioSrc;
    void Start()
    {
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 2f * Time.deltaTime);
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
            Game.Instance.AddToScore(100);
            Destroy(gameObject);
        }
        return;
    }

    if (collision.CompareTag("ScoreBoundary"))
    {
        Game.Instance.SubtractToScore(200);
        Destroy(gameObject);
    }
}
}
