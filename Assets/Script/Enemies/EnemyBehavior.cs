using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject enemy;
    private GameObject player;

    private static int shootInterval = 2; // in seconds ie. 2 --> 2 seconds
    private int shootSteps = shootInterval * 60;
    private int shootCount;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        shootCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.LookAt(player.transform);
        shootCount += 1;

        if (shootCount % shootSteps == 0)
        {
            // shoot
        }
    }
}
