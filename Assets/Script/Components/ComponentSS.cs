using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class ComponentSS : MonoBehaviour
{
    private Dictionary<DirEnum, FixedJoint> joints = new Dictionary<DirEnum, FixedJoint>();

    private Dictionary<DirEnum, GameObject> objs = new Dictionary<DirEnum, GameObject>();
    
    protected DirEnum dir = DirEnum.Front;
    
    protected static float energy;
    protected const float initialMaxEnergy = 10;
    protected static float maxEnergy = 10;
    
    protected bool isEnemy = false;
    protected float health = 10;

    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetToEnemy()
    {
        isEnemy = true;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
    
    void OnDestroy() {
         transform.parent.GetComponent<StarShips>().RemoveComponent(this);   
    }
}
