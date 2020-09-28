using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    void Update()
    {
        if (!Input.GetKey(KeyCode.CapsLock))
        {
            var movement = Camera.main.transform.right * Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");
            var temp = Camera.main.transform.forward;
            temp.y = 0;
            movement += temp.normalized * verticalMovement;
            transform.position += movement;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }
     

        if (Input.GetKey(KeyCode.CapsLock))
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
