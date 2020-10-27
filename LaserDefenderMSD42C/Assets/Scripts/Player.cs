using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //moves the spaceship around
    private void Move()
    {
        //deltaX is updated with the movement in the x-axis (left and right)
        var deltaX = Input.GetAxis("Horizontal");

        //newXPos = current x-pos of Player
        //+ difference in X by keyboard Input
        var newXPos = transform.position.x + deltaX;

        //update the position of the Player
        this.transform.position = new Vector2(newXPos, transform.position.y);
            
    }

   

}
