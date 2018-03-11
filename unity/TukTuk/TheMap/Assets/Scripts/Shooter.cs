﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    // Reference to projectile prefab to shoot
    public GameObject projectile;
    public float power = 10.0f;


    // Update is called once per frame
    void Update()
    {
        // Detect if fire button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            // if projectile is specified
            if (projectile)
            {
                // Instantiante projectile at the camera 
                GameObject newProjectile = (GameObject) Instantiate(projectile, transform.position + transform.forward, transform.rotation);

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);             
            }
        }
    }
}