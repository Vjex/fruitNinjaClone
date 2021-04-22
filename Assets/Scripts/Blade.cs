using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    //Rigibody Of The The Game Object (Blade here ) Variable To Change the Position Og Blade On Movement Of Mouse Within the The Screen World.
    private Rigidbody2D rb;

    //var for Min Mous velocity so that After that Our Collider of Blade Will be Enabled other wise not.
    public float minMousvel = 0.000001f;

    //This Is The Last Mous Position  On Which mous Stops Moving.
    private Vector3 lastMousPos;

    //This Is The Blade Collider2D Var Will Be Assigned Value in Awake Method.
    private Collider2D col;


    //Assigning Values To the Var By The Initial value Of Blade Element\.
     void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }


   
    // Update is called once per frame
    void Update()
    {

        //Collider Of Blade Will only be Enabled If Mouse Is Moving Otherwise No Collision Will be Detected By the Object
        col.enabled = IsMouseMoving();


        //Set Blade ToMouse Movement.
        SetBladeToMouse();


    }

    private void SetBladeToMouse()
    {
        //Now First We Will get The Mouse Position In The 3D World As Its A 3D Project 
        var mosPos = Input.mousePosition;

        //Now Set the Z Position Value Of Mouse to the Value That is of The Camera but With Opposite Sign To MAke Sum To Zero(0) i.e here -10 Z Value Of Camera So +10 here The Mouse Pos Z Value.
        mosPos.z = 10;

        //set Position Og Blade.
        rb.position = Camera.main.ScreenToWorldPoint(mosPos);

    }
    private bool IsMouseMoving()

    {

        //Now First We Will get The Mouse Position In The 3D World As Its A 3D Project 
        var mosPos = Input.mousePosition;

        //Now Set the Z Position Value Of Mouse to the Value That is of The Camera but With Opposite Sign To MAke Sum To Zero(0) i.e here -10 Z Value Of Camera So +10 here The Mouse Pos Z Value.
        mosPos.z = 10;

        //Cur Mous Pos Will Always Be The Mouse Current Position So Assigning Current Position Of Mouse.
        //In Video he Assigned Postion Of Blade But Their Was a Problem that every Time It (lastMousPos - currentMosPos).magnitude gives Approx
        //Value To Zero Which Is Always Shorter Than Our Min Value hence Always This Function Retuning False. 

        Vector3 currentMosPos = mosPos;

        //Get The Distance Between Two Position Of Mouse
        float traveled = (lastMousPos - currentMosPos).magnitude;

        //Assign This New Position of Mouse to Last Pos.
        lastMousPos = currentMosPos;
        
        //If traveled > minVelofMous then Return Mouse Is Moving Otherwise Not.
        if (traveled > minMousvel) {
          
            return true; }
        else {
            return false; 
        }
    }
}
