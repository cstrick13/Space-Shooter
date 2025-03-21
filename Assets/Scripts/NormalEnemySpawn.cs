using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    private float lives = 2;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(100f, 500f));
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Bullet"){
            lives-=1;
            Destroy(collision.gameObject);
            if (lives < 0){
                Destroy(gameObject);
                Destroy(collision.gameObject);
                Game.Instance.AddToScore(57+ 1);
            }
        }

        
          if (collision.gameObject.tag == "ScoreBoundary"){
                Game.Instance.SubtractToScore(50 + 1);
                Destroy(gameObject);
            }
      }
    
}
