using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class Motor : ComponentSS
{
    private float speed = 50;
    
    [SerializeField]
    private float consumption = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemy)
        {
            if (((Input.GetKey(KeyCode.W) && dir == DirEnum.Behind) ||
                 (Input.GetKey(KeyCode.S) && dir == DirEnum.Front) ||
                 (Input.GetKey(KeyCode.A) && dir == DirEnum.Right) ||
                 (Input.GetKey(KeyCode.D) && dir == DirEnum.Left) ||
                 (Input.GetKey(KeyCode.LeftShift) && dir == DirEnum.Down) ||
                 (Input.GetKey(KeyCode.LeftControl) && dir == DirEnum.Up)) && energy > 0)
            {
                transform.GetComponent<Rigidbody>().AddForce(-transform.forward * speed, ForceMode.Force);
                energy -= consumption * Time.deltaTime;
            }
        }
        else
        {
            // Enemy movement is implemented in the controller to be able to access the true forward direction
        }
        
    }
}
