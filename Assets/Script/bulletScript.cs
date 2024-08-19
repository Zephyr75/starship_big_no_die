using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private float bulletLifeTime = 5;
    private int damage = 5;

    private bool isEnemy;
    
    public void SetToEnemy()
    {
        isEnemy = true;
    }
    
    public bool GetEnemyStatus()
    {
        return isEnemy;
    }
    
    private void Awake()
    {
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ComponentSS>() != null)
        {
            other.gameObject.GetComponent<ComponentSS>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
