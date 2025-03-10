using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    private const float G = 0.06674f;
    public static List<Gravity> planetLists;

  

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<Gravity>();
        }
        planetLists.Add(this);
    }
    private void FixedUpdate()
    {
        foreach (var planet in planetLists)
        {
            if(planet != this)
            Attract(planet);
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;

        Vector3 direction = rb.position - otherRb.position;
        //get distance in meter
        float distance = direction.magnitude;
        
        //calculate the gravity force!
        float forcemagnitude = G * (rb.mass * otherRb.mass)/ MathF.Pow(distance, 2);
        Vector3 finalForce = forcemagnitude * direction.normalized;
        
        otherRb.AddForce(finalForce);
    }
}
