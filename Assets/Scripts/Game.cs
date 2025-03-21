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

    public GameObject shootingEnemyPrefab;

    public GameObject fallingObstaclePrefab;
    public TextMeshProUGUI txtScore;

    public GameObject bulletEnemyPrefab;
    private float enemyTimer;

    private float fallingObstacleTimer;
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
        fallingObstacleTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if(enemyTimer < 0){
            Instantiate(enemyPrefab);
            Instantiate(droneEnemyPrefab);
            Instantiate(bulletEnemyPrefab);
            Instantiate(shootingEnemyPrefab);
            enemyTimer = Random.Range(2f,7f);
        }

        fallingObstacleTimer -= Time.deltaTime;
        if(fallingObstacleTimer < 0){
             Instantiate(fallingObstaclePrefab);
             fallingObstacleTimer = Random.Range(2f,7f);
        }

        txtScore.text = score.ToString("000000");
         if (score < 0){
            // this is where we can call the game over screen
            print("Game Over");
        }
    }

       public void AddToScore(float amount) {
        score += amount;
    }

    public void SubtractToScore(float amount){
        score-= amount;
    }
}
