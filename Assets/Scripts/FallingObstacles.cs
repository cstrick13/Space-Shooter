using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initPos = new Vector3(Random.Range(-3f, 4f),12 , 0);
        transform.position = initPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
