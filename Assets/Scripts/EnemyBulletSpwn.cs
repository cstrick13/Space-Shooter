using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 30 * Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
