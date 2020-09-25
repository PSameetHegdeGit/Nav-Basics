using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            var movement = Camera.main.transform.right * Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");
            var temp = Camera.main.transform.forward;
            temp.y = 0;
            movement += temp.normalized * verticalMovement;
            transform.position += movement / 10;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        }
        /*
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
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x + xAxis, transform.position.y + yAxis, transform.position.z + zAxis);
        }
            */

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(-1.0f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, -1.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(1.0f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, 1.0f, 0.0f);
            }
            
        }
    }
}
