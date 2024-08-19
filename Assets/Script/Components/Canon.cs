using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Canon : ComponentSS
{
    [SerializeField]
    private float consumption;
    
    [SerializeField]
    private Transform bulletSpawnPoint;
    
    [SerializeField]
    private GameObject metalBullet;

    private float bulletSpeed = 100;

    private int cooldownTime = 25;

    private int cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldown <= 0 && energy > consumption)
        {
            if (Input.GetKey(KeyCode.Space) && isEnemy == false)
            {
                var bullet = Instantiate(metalBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation * Quaternion.Euler(90, 0, 0));
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                cooldown = cooldownTime;
                energy -= consumption;
            }
        }
        else
        {
            cooldown -= 1;
        }
    }
}
