using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    private float distance = 5.0f;
    private float xSpeed = 500.0f;
    private float ySpeed = 500.0f;

    private float yMinLimit = -80f;
    private float yMaxLimit = 80f;

    private float x = 0.0f;
    private float y = 0.0f;
    
    private float deltaTime = 0.0f;
    private float lastTime = 0.0f;
    
    private Vector3 ratio = new Vector3(0, 0.5f, -1);
    private bool isEditing;


    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        transform.position = target.position - transform.forward * distance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isEditing = !isEditing;
            Time.timeScale = isEditing ? 0.0f : 1.0f;
            print("Switched mode");

            if (isEditing)
            {
                transform.parent = target.parent;
            }
            else
            {
                transform.parent = target;
                transform.localPosition = ratio * distance;
                transform.localEulerAngles = new Vector3(26.6f, 0, 0);
            }
        }
        
        float newTime = Time.realtimeSinceStartup;
        deltaTime = newTime - lastTime;
        lastTime = newTime;
        
        if (Input.GetMouseButton(1) && Time.timeScale == 0.0f)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * deltaTime;
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

        if (Time.timeScale > 0.0f)
        {
            transform.localPosition = ratio * distance;
            transform.localEulerAngles = new Vector3(26.6f, 0, 0);
        }

        
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
