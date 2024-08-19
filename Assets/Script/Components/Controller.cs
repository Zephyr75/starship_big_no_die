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
        energy = initialMaxEnergy;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        energy += refill * Time.deltaTime;

        maxEnergy = initialMaxEnergy + GetBatteriesCount();
        energy = Mathf.Clamp(energy, 0, maxEnergy);
        
        Renderer rend = GetComponent<Renderer>();
        float coeff = 3 * (energy / maxEnergy);
        rend.sharedMaterial.SetColor("_EmissionColor", new Vector4(0, 1.30041f, 1.498039f) * coeff);
    }
}
