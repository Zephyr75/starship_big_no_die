using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private float health = 50;
    private bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.materials[1].SetColor("_EmissionColor", new Vector4(0, 1.30041f, 1.498039f) * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToEnemy()
    {
        isEnemy = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<bulletScript>() != null)
        {
            if (other.gameObject.GetComponent<bulletScript>().GetEnemyStatus() != isEnemy)
            {
                Destroy(other.gameObject);
            
                Renderer rend = GetComponent<Renderer>();
                float coeff = (health / 100);
                rend.materials[1].SetColor("_EmissionColor", new Vector4(0, 1.30041f, 1.498039f) * coeff);
            
                health -= 5;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
