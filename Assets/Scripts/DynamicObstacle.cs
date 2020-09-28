using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour
{
    public double lowerLimit;
    public double upperLimit;
    public char axis;
    private bool switchDirection = false;

    // Update is called once per frame
    void Update()
    {
        if (axis == 'x')
        {
            if (gameObject.transform.localPosition.x < lowerLimit)
            {
                switchDirection = false;
            }
            else if (gameObject.transform.localPosition.x > upperLimit)
            {
                switchDirection = true;
            }

            if (switchDirection)
            {
                transform.Translate(Vector3.left * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * 2 * Time.deltaTime);
            }
        }
        else if (axis == 'y')
        {
            if (gameObject.transform.position.y < lowerLimit)
            {
                switchDirection = false;
            }
            else if (gameObject.transform.position.y > upperLimit)
            {
                switchDirection = true;
            }

            if (switchDirection)
            {
                transform.Translate(Vector3.down * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.up * 2 * Time.deltaTime);
            }
        }
        else if (axis == 'z')
        {
            if (gameObject.transform.position.z < lowerLimit)
            {
                switchDirection = false;
            }
            else if (gameObject.transform.position.z > upperLimit)
            {
                switchDirection = true;
            }

            if (switchDirection)
            {
                transform.Translate(-Vector3.forward * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            }
        }
        



    }
}
