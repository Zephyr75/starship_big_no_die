using System.Collections;
using System.Collections.Generic;
using Script;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
