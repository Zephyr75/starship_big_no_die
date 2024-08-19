using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletLifeTime = 5;
    public int damage = 10; 

    private void Awake()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //other.TakeDommage.healthDwon(damage);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
