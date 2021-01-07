using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    bool coroutineStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    

   

    //sets up the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        //xMin = 0  accaording to the camera view
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    // moves the Player ship
    private void Move()
    {
        //deltaX is the difference we move on the x-axis
        // var is a generic type which changes according to its value
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        // new X position = current position in x-axis + diffrence in x 
        var newXPos = transform.position.x + deltaX;
        //clamp the ship between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // Player position = (new X position, current y position)
        transform.position = new Vector2(newXPos, transform.position.y);

 

    }
}