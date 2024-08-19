using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


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
    
    [SerializeField]
    private ResourcesManager resourcesManager;
    
    [SerializeField]
    private TMP_Text energyText;
    
    [SerializeField]
    private Volume postProcessingVolume;
    
    private ChromaticAberration aberration; 

    private GameObject preview;
    private Transform oldHit;
    private Vector3 oldNormal;

    private ComponentsEnum selectedEnum = ComponentsEnum.Bloc;
    
    void Start()
    {
        prefabsComponents = myMap.ToDictionary();
        GameObject obj = Instantiate(prefabStarShip);
        ship = obj.GetComponent<StarShips>();
        ship.transform.position = new Vector3(-1, 6, -18);
        GameObject motor = Instantiate(prefabsComponents[ComponentsEnum.Motor]);
        motor.transform.position = ship.transform.position - ship.transform.forward * ship.transform.localScale.z * 2;
        motor.transform.eulerAngles += new Vector3(0, 180, 0);
        ComponentSS compMotor = motor.GetComponent<ComponentSS>();
        compMotor.SetDir(DirEnum.Behind);
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

    void CheckKeyDownSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) selectedEnum = ComponentsEnum.Bloc;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) selectedEnum = ComponentsEnum.Motor;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) selectedEnum = ComponentsEnum.Canon;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) selectedEnum = ComponentsEnum.Laser;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) selectedEnum = ComponentsEnum.Shield;
        else if (Input.GetKeyDown(KeyCode.Alpha6)) selectedEnum = ComponentsEnum.Solar;
        else if (Input.GetKeyDown(KeyCode.Alpha7)) selectedEnum = ComponentsEnum.Battery;
        else if (Input.GetKeyDown(KeyCode.Alpha8)) selectedEnum = ComponentsEnum.FieldGen;
    }

    // Update is called once per frame
    void Update()
    {
        energyText.text = (Mathf.Round(ship.GetController().GetEnergy() * 10f) / 10f).ToString() + "/" + ship.GetController().GetMaxEnergy().ToString();
        
        postProcessingVolume.profile.TryGet<ChromaticAberration>(out aberration);
        aberration.intensity.value = ship.transform.GetChild(0).GetComponent<Rigidbody>().velocity.magnitude / 100;
        
        if (Time.timeScale > 0.0f)
        {
            if (preview)
            {
                Destroy(preview);
            }
            return;
        }
        ComponentsEnum oldSelectedEnum = selectedEnum;
        CheckKeyDownSwitch();
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1 << 30 | 1 << 29))
        {
            if ((hit.transform != oldHit || oldNormal != hit.normal || oldSelectedEnum != selectedEnum) && hit.collider.gameObject.layer == 30)
            {
                Destroy(preview);
                Transform hitTransform = hit.transform;
                Vector3 ortho = hitTransform.forward;
                if (Mathf.Abs(Vector3.Dot(Vector3.Normalize(ortho), Vector3.Normalize(hit.normal))) > 0.5)
                {
                    ortho = hitTransform.transform.up;
                }
                preview = Instantiate(prefabsComponents[selectedEnum], hit.transform.position + hit.normal,
                    Quaternion.LookRotation(hit.normal, ortho));
                Renderer previewRenderer = preview.transform.GetChild(0).GetComponent<Renderer>();
                Material[] materials = previewRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = previewMaterial;
                }
                previewRenderer.materials = materials;
                Destroy(preview.GetComponent<Collider>());
                oldHit = hit.transform;
                oldNormal = hit.normal;
                
                StartCoroutine(resourcesManager.UpdateCristal(-20));
                StartCoroutine(resourcesManager.UpdateElectronic(-20));
                StartCoroutine(resourcesManager.UpdateMineral(-20));
                StartCoroutine(resourcesManager.UpdateReinforced(-0));
            } else if (hit.collider.gameObject.layer != 30)
            {
                Destroy(preview);
                oldHit = hit.transform;
                oldNormal = hit.normal;
            }
        }
        else
        {
            Destroy(preview);
            oldHit = null;
            oldNormal = Vector3.forward;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            print(preview);
        }

        if (Input.GetMouseButtonDown(0) && preview)
        {
            GameObject newComponent = Instantiate(prefabsComponents[selectedEnum], preview.transform.position,
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
        if (Vector3.Dot(Vector3.Normalize(forward), Vector3.Normalize(controller.forward)) > 0.5)
        {
            return DirEnum.Front;
        }
        if (Vector3.Dot(Vector3.Normalize(forward), Vector3.Normalize(-controller.forward)) > 0.5)
        {
            return DirEnum.Behind;
        }
        if (Vector3.Dot(Vector3.Normalize(forward), Vector3.Normalize(controller.up)) > 0.5)
        {
            return DirEnum.Up;
        }
        if (Vector3.Dot(Vector3.Normalize(forward), Vector3.Normalize(-controller.up)) > 0.5)
        {
            return DirEnum.Down;
        }
        if (Vector3.Dot(Vector3.Normalize(forward), Vector3.Normalize(controller.right)) > 0.5)
        {
            return DirEnum.Right;
        }
        return DirEnum.Left;
    }

}
