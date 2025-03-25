using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


public class DroneEnemy : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public AudioClip smallexplosionAudio;
    private AudioSource audioSrc;
    public float lives = 3;

    public ParticleSystem smallExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
          Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
          transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position != this.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
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
            Game.Instance.AddToScore(1038);
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
