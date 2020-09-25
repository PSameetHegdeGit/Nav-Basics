using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var movement = Camera.main.transform.right * Input.GetAxis("Horizontal_Obst");
        var verticalMovement = Input.GetAxis("Vertical_Obst");
        var temp = Camera.main.transform.forward;
        temp.y = 0;
        movement += temp.normalized * verticalMovement;
        transform.position += movement / 10;
    }
}