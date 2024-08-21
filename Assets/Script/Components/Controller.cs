using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Controller : ComponentSS
{
    [SerializeField]
    private float refill = 1;

    private StarShips ship;
    
    [SerializeField] protected bool isEnemyController = false;
    
    public float GetEnergy() { return energy; } 
    public float GetMaxEnergy() { return maxEnergy; } 

    private float speed = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        ship = transform.parent.GetComponent<StarShips>();
        energy = initialMaxEnergy;
        isEnemy = isEnemyController;
        if (isEnemyController)
        {
            ship.SetToEnemy();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isEnemy) {
            GameObject player = GameObject.Find("player(Clone)");
            if (player != null) {
                Vector3 playerPosition = player.transform.position;
                Vector3 direction = playerPosition - transform.position;
                if (direction.magnitude > 100) {
                    transform.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Force);
                }

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime, 0.0f);

                Vector3 crossProduct = Vector3.Cross(transform.forward, newDirection);

                float angleDifference = Vector3.Angle(transform.forward, newDirection);
                float torqueMagnitude = angleDifference / 10;

                transform.GetComponent<Rigidbody>().AddTorque(crossProduct.normalized * torqueMagnitude, ForceMode.Acceleration);                
                // transform.rotation = Quaternion.LookRotation(newDirection);     
            }
        }

    
        energy += refill * Time.deltaTime;

        maxEnergy = initialMaxEnergy + GetBatteriesCount();
        energy = Mathf.Clamp(energy, 0, maxEnergy);
        
        Renderer rend = GetComponent<Renderer>();
        float coeff = 3 * (energy / maxEnergy);
        rend.sharedMaterial.SetColor("_EmissionColor", new Vector4(0, 1.30041f, 1.498039f) * coeff);
    }
    
    private int GetBatteriesCount()
    {
        int batteryCount = 0;

        foreach (var obj in ship.GetComponents())
        {
            if (obj.GetComponent<Battery>() != null)
            {
                batteryCount++;
            }
        }

        return batteryCount;
    }
}
