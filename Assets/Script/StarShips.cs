using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShips : MonoBehaviour
{
    private List<Components_SS> components;
    private Controller controller;
    private GameObject prefabController;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
