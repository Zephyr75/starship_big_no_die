using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;using UnityEngine.UIElements;

public class StarShips : MonoBehaviour
{
    [SerializeField] private List<ComponentSS> components;
    [SerializeField]
    private Controller controller;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddComponents(ComponentSS comp)
    {
        Pair<Dictionary<DirEnum, float>, Dictionary<DirEnum, GameObject>> dict = RayAll(comp.transform);
        float minDist = Mathf.Infinity;
        DirEnum minDir = DirEnum.Front;
        foreach (var d in dict.value1)
        {
            if (d.Value < minDist)
            {
                minDist = d.Value;
                minDir = d.Key;
            }
        }

        if (minDist.Equals(Mathf.Infinity))
        {
            return;
        }

        ComponentSS obj = dict.value2[minDir].GetComponent<ComponentSS>();
        if (obj == null)
        {
            return;
        }
        //Debug.Log(minDir);
        components.Add(comp);
        comp.transform.parent = transform;
        Pair<Vector3, float> vectTranspose = Tools.getDirVector(controller.transform, minDir);
        comp.transform.localPosition = obj.transform.localPosition - vectTranspose.value1*vectTranspose.value2;
        comp.AddJoint(minDir, obj.gameObject);
        obj.AddJoint(Tools.InverseDir(minDir), comp.gameObject);
        dict = RayAll(comp.transform);
        foreach (var d in dict.value1)
        {
            Pair<Vector3, float> vect = Tools.getDirVector(controller.transform, d.Key);
            //Debug.Log("Direction in SS " + d.Key);
            if (d.Value < vect.value2 && dict.value2.ContainsKey(d.Key))
            {
                comp.AddJoint(d.Key, dict.value2[d.Key]);
                dict.value2[d.Key].GetComponent<ComponentSS>()?.AddJoint(Tools.InverseDir(d.Key), comp.gameObject);
            }
        }
    }

    public List<ComponentSS> GetComponents()
    {
        return components;
    }

    Pair<Dictionary<DirEnum, float>, Dictionary<DirEnum, GameObject>> RayAll(Transform trans)
    {
        Dictionary<DirEnum, Ray> rays = new Dictionary<DirEnum, Ray>();
        Dictionary<DirEnum, GameObject> dictObj = new Dictionary<DirEnum, GameObject>();
        rays.Add(DirEnum.Front, new Ray(trans.position, controller.transform.forward));
        rays.Add(DirEnum.Behind, new Ray(trans.position, -controller.transform.forward));
        rays.Add(DirEnum.Right, new Ray(trans.position, controller.transform.right));
        rays.Add(DirEnum.Left, new Ray(trans.position, -controller.transform.right));
        rays.Add(DirEnum.Up, new Ray(trans.position, controller.transform.up));
        rays.Add(DirEnum.Down, new Ray(trans.position, -controller.transform.up));
        Dictionary<DirEnum, float> dict = new Dictionary<DirEnum, float>();
        foreach (var ray in rays)
        {
            if (Physics.Raycast(ray.Value, out RaycastHit hit, Mathf.Infinity, 1 << 30))
            {
                dict.Add(ray.Key, hit.distance);
                dictObj.Add(ray.Key, hit.collider.gameObject);
            }
        }
        return new Pair<Dictionary<DirEnum, float>, Dictionary<DirEnum, GameObject>>(dict, dictObj);
    }
}

public class Pair<T, U>
{
    public T value1;
    public U value2;

    public Pair(T v, U w)
    {
        value1 = v;
        value2 = w;
    }
}
