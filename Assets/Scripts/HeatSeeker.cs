using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HeatSeeker : MonoBehaviour
{
    private float moveSpeed = 1f;
    private GameObject nearest = null;
    // Start is called before the first frame update
    void Start()
    {
        //Setting initial variables
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        print(targets.Length);
        Vector3 currentPos = transform.position;
        float minDistance = 0f;
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(currentPos, target.transform.position);
            if (distance < minDistance)
            {
                nearest = target;
                minDistance = distance;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nearest != null)
        {
            //print("Moving towards enemy");
            transform.position = Vector3.MoveTowards(transform.position, nearest.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            //print("No enemy nearby");
        }
    }
}
