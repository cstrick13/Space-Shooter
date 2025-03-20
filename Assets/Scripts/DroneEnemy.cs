using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DroneEnemy : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
          Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
          transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position != this.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
