using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Pioupioupiou : MonoBehaviour

{
    public DirEnum canonOrientation;

    public bool isEnemy = false;

    public Transform bulletSpawnPoint;

    public GameObject metalBullet;

    public float bulletSpeed = 30;

    public int inverseShootSpeed = 25;

    private int stopShoot = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopShoot == 0)
        {
            if (Input.GetKey(KeyCode.Space) && isEnemy == false)
            {
                var bullet = Instantiate(metalBullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation * Quaternion.Euler(90, 0, 0));
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                stopShoot = inverseShootSpeed;
            }
        }
        else
        {
            stopShoot = stopShoot - 1;
        }
           
    }
}
