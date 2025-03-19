using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    //public bool DEBUG;
    public GameObject enemyPrefab;
    public GameObject droneEnemyPrefab;
    public TextMeshProUGUI txtScore;

    public GameObject bulletEnemyPrefab;
    private float enemyTimer;
    private float score = 0;
    public static Game Instance { get; private set; }
    public static GameControls Input { get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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

        txtScore.text = score.ToString("000000");
    }

       public void AddToScore(float amount) {
        score += amount;
    }
}
