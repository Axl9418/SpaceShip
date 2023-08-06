using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //prefab of laser
    [SerializeField] //Allow see _laser on the inspector
    private GameObject _laser;

    //time between a shoot and next one
    [SerializeField]
    private float _shootDelay = 0.05f;
    //exact time when player can shoot again
    private float _canShoot = -1f;
    //lives of the player
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        //setting player position on 0 every time the game starts
        transform.position = new Vector3(0, 0, 0);
    }

    //player movement
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalalInput = Input.GetAxis("Vertical");
        //the vector in which the player is going towards the space
        Vector3 direction = new Vector3(horizontalInput, verticalalInput, 0);

        transform.Translate(direction * 4f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        //LimitSpace();



        //Instantiate laser when spcaebar is pressed and shooting is enabled
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canShoot)
        {
            ShootLaser();
        }
    }

    //Laser shooting
    void ShootLaser()
    {
        //update the delay time for laser shoot
        _canShoot = Time.deltaTime + _shootDelay;

        //instantiate the laser to create a copy of the laser prefab in the position and rotation choosen
        Instantiate(_laser, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
    }

    //player damage
    public void GetDamage()
    {
        //substract lives of the player
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

    
}
