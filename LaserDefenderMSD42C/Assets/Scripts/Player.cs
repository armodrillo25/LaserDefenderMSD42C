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
    [SerializeField] float padding = 0.7f;

    [SerializeField] GameObject laserPrefab;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        //start coroutine
        StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    //Coroutine example:
    private IEnumerator PrintAndWait()
    {
        print("Message 1");
        //pause coroutine execution for 10 seconds
        yield return new WaitForSeconds(10);
        print("Message 2 after 10 seconds");
    }
    

    private void Fire()
    {
        //whenever I fire
        if (Input.GetButtonDown("Fire1"))
        {
            //create a Laser Prefab, at the Player position
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            //gives velocity to each laser in the y-axis
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15f);

        }
    }

    //setup the boundaries according to the camera
    private void SetUpMoveBoundaries()
    {
        //get the camera from Unity
        Camera gameCamera = Camera.main;

        //xMin = 0  xMax = 1
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        //yMin = 0   yMax = 1
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    //moves the spaceship around
    private void Move()
    {
        //deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed ; 
        
        //newXPos = current x-pos of Player
        //+ difference in X by keyboard Input
        var newXPos = transform.position.x + deltaX;
        //clamps the newXPos between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //the same as above but in the y-axis
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //update the position of the Player
        this.transform.position = new Vector2(newXPos, newYPos);
            
    }

   

}
