using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyToSpawn;
    private Vector3 playerPosition;
    public int enemyAlive = 0;
    public int maxEnemy = 6;

    public int facterScaleDueToShipScale = 1;
    
    void Start()
    { 
        




    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.Find("player").transform.position;
        transform.position = playerPosition;

        if (enemyAlive < maxEnemy)
        {
            int pm = Random.Range(0, 2);
            if (pm == 0)
            {
                pm = -1;
            }
            
            Vector3 enemyPosition = GetSpawnPosition() + new Vector3(20 * pm, 20 * pm, 20 * pm);
            Instantiate(enemyToSpawn[Random.Range(0,1)], enemyPosition, Quaternion.identity);

            enemyAlive = enemyAlive + 1;
        }
        

    }

    Vector3 GetSpawnPosition()
    {
        float xEnemy = Random.Range(-200*facterScaleDueToShipScale, 200*facterScaleDueToShipScale);
        float yEnemy = Random.Range(-200*facterScaleDueToShipScale, 200*facterScaleDueToShipScale);
        float zEnemy = Random.Range(-200*facterScaleDueToShipScale, 200*facterScaleDueToShipScale);

        Vector3 enemyInitialPosition = new Vector3(xEnemy, yEnemy, zEnemy);

        return enemyInitialPosition;
    }
}
