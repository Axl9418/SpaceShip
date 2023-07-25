using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed of laser
    private float _speed = 6f;
    //limit of space
    private float _yLimit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //laser move up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        //destroy laser when is off of the limit space "y"
        if (transform.position.y > _yLimit)
        {
            Destroy(gameObject);
        }

    }
}
