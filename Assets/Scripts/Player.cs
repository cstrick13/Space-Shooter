using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public GameObject bulletPrefab;
    public Transform spawnPt;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var input = Game.Input.Standard;
        if (input.ShootBullet.WasPressedThisFrame()){
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPt.position;
        }
    }
}
