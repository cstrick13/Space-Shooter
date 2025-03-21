using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 50 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Game.Instance.AddToScore(1037 + 1);
        }
    }
}
