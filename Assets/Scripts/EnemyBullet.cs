using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    private float lives = 1;

    public ParticleSystem smallExplosionPrefab;
    void Start()
    {
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 25 * Time.deltaTime);
    }

      void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Bullet"){
            lives-=1;
            Destroy(collision.gameObject);
            if (lives < 0){
                Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Game.Instance.AddToScore(100 + 1);
            }
        }
             if (collision.gameObject.tag == "ScoreBoundary"){
                Game.Instance.SubtractToScore(200 + 1);
                Destroy(gameObject);
            }
      }
}
