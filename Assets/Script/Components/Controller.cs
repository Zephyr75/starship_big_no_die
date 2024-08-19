using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : ComponentSS
{
    [SerializeField]
    private float refill = 1;
    
    public float GetEnergy() { return energy; } 
    public float GetMaxEnergy() { return maxEnergy; } 
    
    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        energy += refill * Time.deltaTime;
        // print(energy);
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }

        if (energy < 0)
        {
            energy = 0;
        }
        
        Renderer rend = GetComponent<Renderer>();
        float coeff = 3 * (energy / maxEnergy);
        rend.sharedMaterial.SetColor("_EmissionColor", new Vector4(0, 1.30041f, 1.498039f) * coeff);
    }
}
