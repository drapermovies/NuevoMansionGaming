﻿//Made by Joel Draper for MansionGaming 
using UnityEngine;
using System.Collections;

public class playerScaling : MonoBehaviour {

    public HealthBasics health;
    public PlayerFunctions player;

    public float scale, lastScale = 3f;

    void Update() {
        CheckHealth();
    }

    void CheckHealth()
    {
        player.GCRadius = scale; //Ground Check Radius varies depending on player scale

        if (health.health > 100)
        {
            scale = 2f; //If player has more health then average "full" health, they are 8 times bigger then normal
            GetComponent<Rigidbody2D>().gravityScale = 20;
        }
        if (health.health <= 100)
        {
            scale = 1.25f; //If player has less than or equal to "full" health, they are 5 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if (health.health < 95)
            scale = 1.1875f; //If player has less than 95 health points, they are 4.75 times bigger than normal
        if (health.health < 90)
        {
            scale = 1.125f; //If player has less than 90 health points, they are 4.5 times bigger than normal 
            GetComponent<Rigidbody2D>().gravityScale = 9;
        }
        if (health.health < 85)
            scale = 1.0625f; //If player has less than 85 health points, they are 4.25 times bigger than normal
        if (health.health < 80)
        {
            scale = 1f; //If player has less than 80 health points, they are 4 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 8;
        }
        if (health.health < 75)
            scale = 1.875f; //If player has less than 75 health points, they are 3.25 times bigger than normal
        if (health.health < 70)
        {
            scale = 0.9375f; //If player has less than 70 health points, they are 3.5 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 7;
        }
        if (health.health < 65)
            scale = 0.8125f; //If player has less than 65 health points, they are 3.25 times bigger than normal 
        if (health.health < 60)
        {
            scale = 0.75f; //If player has less than 60 health points, they are 3 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 6;
        }
        if (health.health < 55)
            scale = 0.6875f; //If player has less than 55 health points, they are 2.75 times bigger than normal 
        if (health.health < 50)
        {
            scale = 0.625f; //If player has less than 50 health points, they are 2.5 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 5;
        }
        if (health.health < 45)
            scale = 0.5625f; //If player has less than 45 health points, they are 2.25 times bigger than normal 
        if (health.health < 40)
        {
            scale = 0.5f;
            GetComponent<Rigidbody2D>().gravityScale = 4;
        }
        if (health.health < 35)
            scale = 0.4375f; //If player has less than 35 health points, they are 1.75 times bigger than normal 
        if (health.health < 30)
        {
            scale = 0.375f; //If player has less than 30 health points, they are 1.5 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }
        if (health.health < 25)
            scale = 0.625f; //If player has less than 25 health points, they are 1.25 times bigger than normal 
        if (health.health < 20)
        {
            scale = 0.5f; //If player has less than 20 health points, they are normal size.
            GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        if (health.health < 15)
            scale = 0.375f; //If player has less than 15 health points, they are 0.75 of normal size. 
        if (health.health < 10)
        {
            scale = 0.0625f; //If player has less than 10 health points, they are 0.5 times bigger than normal
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (health.health < 5)
            scale = 0.03125f; //If player has less than  5 health points, they are 0.25 times bigger than normal 

        if (scale != lastScale) // small optimization to prevent setting the transform each frame
           {
               transform.localScale = new Vector3(scale, scale, scale); //Transforms the scale on all Axis. 
               lastScale = scale; //Not sure about this (lost contact of person who told me to add it) 
           }  
    }
}
