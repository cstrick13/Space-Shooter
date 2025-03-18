using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float dFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        dFromPlayer = 7.5f;
        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Find the point x amount in front of players current position to move towards.
        Vector3 align = new Vector3((target.transform.position.x+dFromPlayer),target.transform.position.y,target.transform.position.z);
        print(target.transform.position);
        if (target.transform.position != this.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, align, moveSpeed * Time.deltaTime);
            print((transform.position.x,transform.position.y,0));
        }
    }
}
