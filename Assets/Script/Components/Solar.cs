using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solar : ComponentSS
{
    [SerializeField]
    private float refill = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        energy += refill * Time.deltaTime;
    }
}
