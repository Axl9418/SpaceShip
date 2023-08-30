using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    /*public GameObject enemyPrefab;

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
    }*/
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 xPosition = new Vector3(Random.Range(-10f, 10f), 6, 0);
            GameObject newEnemy = Instantiate(_enemy, xPosition, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }
}
