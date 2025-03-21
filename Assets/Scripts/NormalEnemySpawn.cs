using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
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
}
