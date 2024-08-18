using System;
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
    
    [SerializeField]
    private Material previewMaterial;

    private GameObject preview;
    private Transform oldHit;
    private Vector3 oldNormal;
    
    void Start()
    {
        prefabsComponents = myMap.ToDictionary();
        GameObject obj = Instantiate(prefabStarShip);
        ship = obj.GetComponent<StarShips>();
        ship.transform.position = new Vector3(-1, 6, -18);
        GameObject motor = Instantiate(prefabsComponents[ComponentsEnum.Motor]);
        motor.transform.position = ship.transform.position - ship.transform.forward * ship.transform.localScale.z * 2;
        ComponentSS compMotor = motor.GetComponent<ComponentSS>();
        compMotor.SetDir(DirEnum.Front);
        if (compMotor != null)
        {
            ship.AddComponents(compMotor);
        }
        
        GameObject canon = Instantiate(prefabsComponents[ComponentsEnum.Canon]);
        canon.transform.position = ship.transform.position + ship.transform.forward * ship.transform.localScale.z * 2;
        ComponentSS compCanon = canon.GetComponent<ComponentSS>();
        compCanon.SetDir(DirEnum.Front);
        if (compCanon != null)
        {
            ship.AddComponents(compCanon);
        }
        DebugTools.DebugFixedJoint(ship);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0.0f)
        {
            if (preview)
            {
                Destroy(preview);
            }
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform != oldHit || oldNormal != hit.normal)
            {
                Destroy(preview);
                Transform hitTransform = hit.transform;
                Vector3 ortho = hitTransform.forward;
                if (Vector3.Dot(ortho, hit.normal) != 0)
                {
                    ortho = hitTransform.transform.up;
                }
                preview = Instantiate(prefabsComponents[ComponentsEnum.Canon], hit.transform.position + hit.normal,
                    Quaternion.LookRotation(hit.normal, ortho));
                Renderer previewRenderer = preview.GetComponent<Renderer>();
                Material[] materials = previewRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = previewMaterial;
                }
                previewRenderer.materials = materials;
                Destroy(preview.GetComponent<Collider>());
                oldHit = hit.transform;
                oldNormal = hit.normal;
            }
        }

        if (Input.GetMouseButtonDown(0) && preview)
        {
            GameObject newComponent = Instantiate(prefabsComponents[ComponentsEnum.Canon], preview.transform.position,
                preview.transform.rotation);
            ComponentSS comp = newComponent.GetComponent<ComponentSS>();
            print(getDirection(preview.transform.forward));
            comp.SetDir(getDirection(preview.transform.forward));
            if (comp != null)
            {
                ship.AddComponents(comp);
            }
        }
    }

    DirEnum getDirection(Vector3 forward)
    {
        Transform controller = ship.GetController().transform;
        if (forward == controller.forward)
        {
            return DirEnum.Front;
        }
        if (forward == -controller.forward)
        {
            return DirEnum.Behind;
        }
        if (forward == controller.up)
        {
            return DirEnum.Up;
        }
        if (forward == -controller.up)
        {
            return DirEnum.Down;
        }
        if (forward == controller.right)
        {
            return DirEnum.Right;
        }
        return DirEnum.Left;
    }

}
