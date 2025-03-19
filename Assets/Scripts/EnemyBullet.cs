using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initPos = new Vector3(12, Random.Range(-3f, 3f), 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 30 * Time.deltaTime);
    }
}
