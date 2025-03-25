using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrate : MonoBehaviour
{
    private GameObject player;
    public AudioClip powerUpAudio;

    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 2.5f * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player playerComponents = GameObject.FindWithTag("Player").GetComponent<Player>();
            playerComponents.hasSeeker = true;
             AudioSource.PlayClipAtPoint(powerUpAudio, transform.position);
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }
}
