using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed of enemy
    private float _speed = 4f;
    // Y limit for destruction
    private float _yLimit = -5f;
    // Y position to respawn at
    private float _respawnY = 6f; 

    private void Start()
    {
        // Set initial random X position
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, _respawnY, 0f);
    }

    private void Update()
    {
        // Move the enemy down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // Check if enemy is below minY and respawn
        if (transform.position.y < _yLimit)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Set new random X position
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, _respawnY, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (!(player is null))
            {
                player.GetDamage();
            }
            //damage the player before destroying this enemy
            Destroy(this.gameObject);
        }
        else if(other.tag == "Laser")
        {
            //destroy the laser when it touch an enemy
            Destroy(other.gameObject);
            //destroy the enemy if the laser or player touch it
            Destroy(this.gameObject);
        }
    }
}
