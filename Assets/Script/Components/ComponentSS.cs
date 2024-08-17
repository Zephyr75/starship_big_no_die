using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSS : MonoBehaviour
{
    [SerializeField] private bool isController;

    private FixedJoint[] joints;
    // Start is called before the first frame update
    void Start()
    {
        joints = GetComponents<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
