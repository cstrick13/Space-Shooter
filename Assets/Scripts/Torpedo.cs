using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    private int timer = 0;
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
        if (timer > 75)
        {
            torpedoRigid.gravityScale = 0.0f;
            //Zero out the velocity before sending it forward.
            torpedoRigid.velocity = Vector3.zero;
            //Vector to move forward
            transform.Translate(Vector3.right * 25 * Time.deltaTime);
        }
        else
        {
            torpedoRigid.gravityScale = 1.0f;
            timer += 1;
        }
    }
}
