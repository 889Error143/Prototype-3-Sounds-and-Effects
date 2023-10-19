using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float _speed = 15f;
    private PlayerController _playerControllerScript;
    private float _leftBounds = -15;

    // Start is called before the first frame update
    void Start()
    {
        
        _playerControllerScript = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
        if (transform.position.x < _leftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }


    }
}
