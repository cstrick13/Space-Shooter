using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    private int time = 0;
    private Rigidbody2D torpedoRigid;
    // Start is called before the first frame update
    void Start()
    {
        print("Object Create");
        torpedoRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 100)
        {
            torpedoRigid.gravityScale = 0.0f;
            //Vector for negating the velocity from initial gravity(for now, value manually adjusted)
            transform.Translate(Vector3.up * 6.1f * Time.deltaTime);
            //Vector to move forward
            transform.Translate(Vector3.right * 25 * Time.deltaTime);
        }
        else
        {
            torpedoRigid.gravityScale = 1.0f;
            time += 1;
            print(time);
        }
        //transform.Translate(Vector3.right * 25 * Time.deltaTime);
    }
}
