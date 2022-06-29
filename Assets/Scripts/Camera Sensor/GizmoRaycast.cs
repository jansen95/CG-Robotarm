using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GizmoRaycast : MonoBehaviour
{
    public Camera robotCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.green;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }

    private void OnDrawGizmos()
    {

        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f))
        {
            //Debug.Log("Hit Something");
            //Gizmos.DrawRay(robotCamera.transform.position, robotCamera.transform.TransformDirection(Vector3.forward) * hitInfo.distance);
        }
        */
    }
}
