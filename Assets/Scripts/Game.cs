using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public bool DEBUG;
    public GameObject enemyPrefab;
    public GameObject droneEnemyPrefab;
    public Transform devSpawn;
    public GameObject seekerCratePrefab;

    public GameObject shootingEnemyPrefab;
    
    public GameObject bossincoming;   
    public TextMeshProUGUI txtScore;

 
    public GameObject fallingObstaclePrefab;
    public GameObject bulletEnemyPrefab;
    public GameObject bossPrefab;
    public GameObject flashbangPIC;

 
    public float bossSpawnDelay = 30f;
    public float bossBannerDuration = 3f;
    private float enemyTimer;
    private float fallingObstacleTimer;
    private float bossTimer;

    private bool bossSpawned = false;
    private bool bossBannerVisible = false;
    private float bossBannerTimer;
    private float score = 0;

    private float crateTimer;
    public float crateDelay;
    private bool crateSpawned;

    public static Game Instance { get; private set; }
    public static GameControls Input { get; private set; }
    public float alpha = 1f;

    void Start()
    {
        Instance = this;
        Input = new GameControls();
        Input.Enable();
        crateTimer = Time.time;
        enemyTimer = 3f;
        crateSpawned = false;
        fallingObstacleTimer = 1f;
        bossTimer = bossSpawnDelay;

        if (bossincoming != null) 
            bossincoming.SetActive(false);
    }

    void Update()
    {

        if (flashbangPIC.activeInHierarchy){
            flashbangPIC.GetComponent<Image>().color = new Color(255f, 255f, 255f, alpha);
            alpha -= 0.005f; 
            Debug.Log(1);   
        }
         if (!bossSpawned)
        {
            enemyTimer -= Time.deltaTime;
            if (enemyTimer <= 0f)
            {
                Instantiate(enemyPrefab);
                Instantiate(droneEnemyPrefab);
                Instantiate(shootingEnemyPrefab);
                Instantiate(bulletEnemyPrefab);
                enemyTimer = Random.Range(2f, 7f);
            }
        }
    // Boss spawn logic
    if (!bossSpawned)
    {
        bossTimer -= Time.deltaTime;

        // Time to show banner
        if (bossTimer <= 0f && !bossBannerVisible)
        {
            ShowBossBanner();
            
        }

        // After banner finishes, spawn boss
        if (bossBannerVisible && bossBannerTimer <= 0f)
        {
            ClearAllRegularEnemies();
            Instantiate(bossPrefab);
            bossSpawned = true;
            bossincoming.SetActive(false);
            bossBannerVisible = false;
        }
    }
        //Spawn seeker crate logic
        if ((Time.time - crateTimer > crateDelay) && crateSpawned != true)
        {
            Instantiate(seekerCratePrefab);
            crateSpawned = true;
        }
    // Banner countdown
    if (bossBannerVisible)
    {
        bossBannerTimer -= Time.deltaTime;
    }

    // Falling obstacles (unchanged)
    fallingObstacleTimer -= Time.deltaTime;
    if (fallingObstacleTimer <= 0f)
    {
        Instantiate(fallingObstaclePrefab);
        fallingObstacleTimer = Random.Range(2f, 7f);
    }

    txtScore.text = score.ToString("000000");
    if (score < 0) Debug.Log("Game Over");


    }

    private void ShowBossBanner()
    {
        if (bossincoming != null)
        {
            bossincoming.SetActive(true);
            bossBannerVisible = true;
            bossBannerTimer = bossBannerDuration;
        }
    }

    public void AddToScore(float amount) => score += amount;
    public void SubtractToScore(float amount) => score -= amount;

    private void ClearAllRegularEnemies()
    {
        foreach (string tag in new[] { "Enemy", "Bullet","Torpedo","HeetSeeker" })
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag(tag))
                Destroy(go);
        }
    }

    public void die(){
        flashbangPIC.SetActive(true);
    }
}
