using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private void Start()
    {
        //Make the first enemy
        SpawnEnemy(); 
    }

    private void Update()
    {
        // Check for missing enemies and respawn
        int activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (activeEnemies < 1)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //Create a new enemy
        Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
    }
}
