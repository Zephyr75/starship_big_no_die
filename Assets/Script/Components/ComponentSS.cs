using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class ComponentSS : MonoBehaviour
{
    [SerializeField] private bool isController;

    private Dictionary<DirEnum, FixedJoint> joints = new Dictionary<DirEnum, FixedJoint>();

    private Dictionary<DirEnum, GameObject> objs = new Dictionary<DirEnum, GameObject>();
    
    private DirEnum dir = DirEnum.Front;
    
    protected static float energy = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDir(DirEnum newDir)
    {
        dir = newDir;
    }

    public Dictionary<DirEnum, FixedJoint> Getjoints()
    {
        return joints;
    }
    
    public Dictionary<DirEnum, GameObject> GetObj()
    {
        return objs;
    }

    public void AddJoint(DirEnum direction, GameObject obj)
    {
        if (!(joints.ContainsKey(direction)))
        {
            FixedJoint fix = gameObject.AddComponent<FixedJoint>();
            Rigidbody rb = obj.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                fix.connectedBody = rb;
                joints.Add(direction, fix);
                objs.Add(direction, obj);
            }
        }
    }
}
