using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGen : ComponentSS
{
    [SerializeField]
    private GameObject fieldPrefab;
    
    [SerializeField]
    private float consumption = 2;
    
    private GameObject fieldInstance;
    
    private bool isActive = false;
    
    private float cooldown = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        fieldInstance = Instantiate(fieldPrefab, transform.position, Quaternion.identity);
        fieldInstance.transform.SetParent(transform);
        fieldInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        
        if (!isEnemy)
        {
        
            if (Input.GetKeyDown(KeyCode.F) && cooldown <= 0 && energy > 0)
            {
                isActive = !isActive;
                fieldInstance.SetActive(isActive);
            }
        
            if (cooldown > 0 || energy <= 0)
            {
                isActive = false;
                fieldInstance.SetActive(false);
            }

            if (isActive)
            {
                energy -= consumption * Time.deltaTime;
            }

            if (fieldInstance == null)
            {
                fieldInstance = Instantiate(fieldPrefab, transform.position, Quaternion.identity);
                fieldInstance.transform.SetParent(transform);
                fieldInstance.SetActive(false);
                cooldown = 10;
            }
        }
        else
        {
            if (fieldInstance != null)
            {
                fieldInstance.GetComponent<Field>().SetToEnemy();
            }
            
            if (fieldInstance == null)
            {
                fieldInstance = Instantiate(fieldPrefab, transform.position, Quaternion.identity);
                fieldInstance.transform.SetParent(transform);
                fieldInstance.SetActive(false);
                cooldown = 10;
            }
            
            if (cooldown <= 0)
            {
                fieldInstance.SetActive(true);
            }
            
        }
    }
}
