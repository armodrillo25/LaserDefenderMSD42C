using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    //a variable that can be edited from Unity    
    [SerializeField] float moveSpeed = 10f;

    float xMin, xMax, yMin, yMax;

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

    //setup the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;

        //xMin = 0  xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        //yMin = 0   yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }

    //moves the spaceship around
    private void Move()
    {
        //deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed ; 
        
        //newXPos = current x-pos of Player
        //+ difference in X by keyboard Input
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //the same as above but in the y-axis
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        //update the position of the Player
        this.transform.position = new Vector2(newXPos, newYPos);
            
    }

   

}
