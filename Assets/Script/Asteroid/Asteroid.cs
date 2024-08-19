using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject brokenPrefab;
    
    private float health = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<bulletScript>() != null)
        {
            Destroy(collision.gameObject);
            
            health -= 5;
            if (health <= 0)
            {
                StartCoroutine(GameObject.Find("Canvas").gameObject.GetComponent<ResourcesManager>().UpdateCristal(20));
                StartCoroutine(GameObject.Find("Canvas").gameObject.GetComponent<ResourcesManager>().UpdateElectronic(50));
                StartCoroutine(GameObject.Find("Canvas").gameObject.GetComponent<ResourcesManager>().UpdateMineral(80));
                StartCoroutine(GameObject.Find("Canvas").gameObject.GetComponent<ResourcesManager>().UpdateReinforced(0));
                Instantiate(brokenPrefab, transform.position, Quaternion.identity);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                Destroy(gameObject, 5f);
            }
        }
    }
}
