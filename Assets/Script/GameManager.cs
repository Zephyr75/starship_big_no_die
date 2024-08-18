using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject prefabStarShip;
    private Dictionary<ComponentsEnum, GameObject> prefabsComponents;
    
    [SerializeField]
    private SerializableDictionary<ComponentsEnum, GameObject> myMap;
    
    private StarShips ship;
    
    void Start()
    {
        prefabsComponents = myMap.ToDictionary();
        GameObject obj = Instantiate(prefabStarShip);
        ship = obj.GetComponent<StarShips>();
        ship.transform.position = new Vector3(-1, 6, -18);
        GameObject motor = Instantiate(prefabsComponents[ComponentsEnum.Motor]);
        motor.transform.position = ship.transform.position - ship.transform.forward * ship.transform.localScale.z * 2;
        ComponentSS compMotor = motor.GetComponent<ComponentSS>();
        if (compMotor != null)
        {
            ship.AddComponents(compMotor);
        }
        
        GameObject canon = Instantiate(prefabsComponents[ComponentsEnum.Canon]);
        canon.transform.position = ship.transform.position + ship.transform.forward * ship.transform.localScale.z * 2;
        ComponentSS compCanon = canon.GetComponent<ComponentSS>();
        if (compCanon != null)
        {
            ship.AddComponents(compCanon);
        }
        DebugTools.DebugFixedJoint(ship);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
