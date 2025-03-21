using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DroneEnemy : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float lives = 4;

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
        if (collision.gameObject.tag == "Bullet"){
            lives-=1;
            Destroy(collision.gameObject);
            if (lives < 0){
                Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Game.Instance.AddToScore(1037 + 1);
            }
        }

             if (collision.gameObject.tag == "ScoreBoundary"){
                Game.Instance.SubtractToScore(800 + 1);
                Destroy(gameObject);
            }
    }
}
