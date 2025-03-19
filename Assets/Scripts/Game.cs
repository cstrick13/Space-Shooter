using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    //public bool DEBUG;
    public GameObject enemyPrefab;
    public GameObject droneEnemyPrefab;

    public GameObject bulletEnemyPrefab;
    public float enemyTimer;
    public static GameControls Input { get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        Input = new GameControls();
        Input.Enable();
        enemyTimer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if(enemyTimer < 0){
            Instantiate(enemyPrefab);
            Instantiate(droneEnemyPrefab);
            Instantiate(bulletEnemyPrefab);
            enemyTimer = Random.Range(2f,7f);
        }
    }
}
