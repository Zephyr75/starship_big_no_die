using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    
    private Vector3 vect = new Vector3(0, 1, -2);
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = vect*3;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = vect;
    }
}
