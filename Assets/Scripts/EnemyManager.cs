using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints; // spawn point for our enemies
    public GameObject[] enemyTypes; //contains our different enemy types
    public List<GameObject> enemies; //a list containing our enemies
    public string[] enemyNames;
    public string playerName = "Sarah";

    void Start()
    {
        enemies.Add(enemyTypes[0]);
        enemies.Add(enemyTypes[1]);
        enemies.Add(enemyTypes[2]);
        enemies.Add(enemyTypes[3]);
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        
        {
            SpawnEnemy();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            KillEnemy();
        }
    }
    void SpawnEnemy()
    {
        int enemyNumber = Random.Range(0, enemyTypes.Length);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject enemy=Instantiate(enemyTypes[enemyNumber], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation,transform);
        enemies.Add(enemy);
        print(enemies.Count);
    }

    void KillEnemy()
    {
        Destroy(enemies[0]);
        print(enemies.Count);
    }
}
