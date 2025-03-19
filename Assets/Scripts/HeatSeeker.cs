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
        //Find the nearest "Enemy" on projectile creation
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 currentPos = transform.position;
        float minDistance = 1000f;
        foreach (GameObject target in targets)
        {
            print(target.name);
            float distance = Vector3.Distance(currentPos, target.transform.position);
            print(distance < minDistance);
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
            transform.position = Vector3.MoveTowards(transform.position, nearest.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
