using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrate : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerComponents = GameObject.FindWithTag("Player").GetComponent<Player>();
            playerComponents.hasSeeker = true;
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
}
