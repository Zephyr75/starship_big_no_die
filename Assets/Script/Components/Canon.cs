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

    private int cooldownTimePlayer = 25;
    private int cooldownTimeEnemy = 50;
    
    private int cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isEnemy)
        {
            if (cooldown <= 0 && energy > consumption)
            {
                if (Input.GetKey(KeyCode.Space) && isEnemy == false)
                {
                    var bullet = Instantiate(metalBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation * Quaternion.Euler(90, 0, 0));
                    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                    cooldown = cooldownTimePlayer;
                    energy -= consumption;
                }
            }
            else
            {
                cooldown -= 1;
            }
        }
        else
        {
            GameObject player = GameObject.Find("player(Clone)");
            float distance = 0;
            if (player != null) {
                Vector3 playerPosition = player.transform.position;
                Vector3 direction = playerPosition - transform.position;
                distance = direction.magnitude;
            }
            if (cooldown <= 0 && distance <= 50)
            {
                var bullet = Instantiate(metalBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation * Quaternion.Euler(90, 0, 0));
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                bullet.GetComponent<bulletScript>().SetToEnemy();
                cooldown = cooldownTimeEnemy;
            }
            else
            {
                cooldown -= 1;
            }
            
        }
        
    }
}
