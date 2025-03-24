using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public GameObject torpedoPrefab;
    public GameObject seekerPrefab;
    public Transform spawnPt;

    public int lives = 6;
    public Image[] livesUI;

    private float delay;
    public ParticleSystem smallExplosionPrefab;

    public ParticleSystem explosionPrefab;

    public float explosionDuration = 1.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
            Destroy(bullet, 2f);
        }
        if (input.ShootTorpedo.WasPressedThisFrame())
        {
            var torpedo = Instantiate(torpedoPrefab);
            torpedo.transform.position = spawnPt.position;
            Destroy(torpedo, 2f);
        }
        if (input.ShootSeeker.WasPressedThisFrame())
        {
            var seeker = Instantiate(seekerPrefab);
            seeker.transform.position = spawnPt.position;
            //DEV: May not want to destoy with timer due to nature of projectile
            Destroy(seeker, 10f);
        }

        float up    = input.FlyUp.ReadValue<float>();
        float down  = input.FlyDown.ReadValue<float>();
        float left  = input.FlyLeft.ReadValue<float>();
        float right = input.FlyRight.ReadValue<float>();
        // Move exactly as before
        transform.Translate(Vector3.up    * moveSpeed * Time.deltaTime * up);
        transform.Translate(Vector3.down  * moveSpeed * Time.deltaTime * down);
        transform.Translate(Vector3.left  * moveSpeed * Time.deltaTime * left);
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * right);
        // Play flame when moving (up/down/right) — stop when moving
        //if ((up > 0f || down > 0f || right > 0f) && left == 0f){
             //flameEffect.Play();
        //}else{
            //flameEffect.Stop();
        //}
    }

    void OnTriggerEnter2D(Collider2D collision){
    if (collision.CompareTag("Enemy"))
    {
        Debug.Log("Life lost due to collision with: " + collision.gameObject.name);
        Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);

        lives--;
        for (int i = 0; i < livesUI.Length; i++)
            livesUI[i].enabled = (i < lives);

        if (lives <= 0)
        {
            Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            // Game Over here
        }
    }
    else if (collision.CompareTag("Boss"))
    {
        Debug.Log("Life lost due to collision with Boss");
        Instantiate(smallExplosionPrefab, collision.transform.position, Quaternion.identity);

        lives--;
        for (int i = 0; i < livesUI.Length; i++)
            livesUI[i].enabled = (i < lives);

        if (lives <= 0)
        {
            Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            // Game Over here
        }
      
    }
}


      void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
    }

}
