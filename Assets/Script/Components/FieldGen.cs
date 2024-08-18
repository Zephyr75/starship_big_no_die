using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGen : ComponentSS
{
    [SerializeField]
    private GameObject fieldPrefab;
    
    private GameObject fieldInstance;
    
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        fieldInstance = Instantiate(fieldPrefab, transform.position, Quaternion.identity);
        fieldInstance.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isActive = !isActive;
            fieldInstance.SetActive(isActive);
        }

        if (isActive)
        {
            energy -= Time.deltaTime;
        }
    }
}
