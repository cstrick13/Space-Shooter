using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float dFromPlayer;
    public GameObject bulletPrefab;
    private int timer = 0;
    public Transform spawnPt;
    public int delayShoot = 100;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        //bulletPrefab = Resources.Load<GameObject>("Prefabs/EnemyBullet");
        dFromPlayer = 7.5f;
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Find the point x amount in front of players current position to move towards.
        Vector3 align = new Vector3((target.transform.position.x+dFromPlayer),target.transform.position.y,target.transform.position.z);
        if (target.transform.position != this.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, align, moveSpeed * Time.deltaTime);
        }
        if (timer > delayShoot)
        {
            if (bulletPrefab != null)
            {
                print("shooting!");
                var bullet = Instantiate(bulletPrefab);
                bullet.transform.position = spawnPt.position;
            }
            timer = 0;
        }
        else
        {
            timer += 1;
        }
    }
}
