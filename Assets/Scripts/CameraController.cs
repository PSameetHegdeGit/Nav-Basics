using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        float yAxis = 0.0f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            yAxis = -1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            yAxis = 1;
        }

        transform.position = new Vector3(transform.position.x + xAxis, transform.position.y + yAxis, transform.position.z + zAxis);
    }
}
