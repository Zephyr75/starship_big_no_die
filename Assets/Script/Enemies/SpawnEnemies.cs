using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemyToSpawn;

    private Vector3 playerPosition;

    private int scale = 1;

    private float cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
    
        if (cooldown < 0)
        {
            Vector3 enemyPosition = GetSpawnPosition();
            Instantiate(enemyToSpawn[Random.Range(0,1)], enemyPosition, Quaternion.identity);

            cooldown = Random.Range(0, 10);
        }
    }

    int GetRandomDirection() {
        return 2 * Random.Range(0, 2) - 1;
    }

    Vector3 GetSpawnPosition()
    {

        float xEnemy = GetRandomDirection() * Random.Range(20*scale, 200*scale);
        float yEnemy = GetRandomDirection() * Random.Range(20*scale, 200*scale);
        float zEnemy = GetRandomDirection() * Random.Range(20*scale, 200*scale);

        Vector3 enemyInitialPosition = new Vector3(xEnemy, yEnemy, zEnemy);

        return enemyInitialPosition;
    }
}
