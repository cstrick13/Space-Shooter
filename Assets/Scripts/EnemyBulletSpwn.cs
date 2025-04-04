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
        transform.Translate(Vector3.left * 7.5f * Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.CompareTag("Torpedo") || collision.gameObject.CompareTag("HeetSeeker"))
        {
            if (collision.gameObject.CompareTag("Torpedo") == true)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

    }
}
