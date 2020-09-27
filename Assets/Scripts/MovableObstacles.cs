using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObstacles : MonoBehaviour
{

    public string selectableTag = "movableObject";
    private Transform movableObject;

    // Start is called before the first frame update
    void Start()
    {
        movableObject = null;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Ray clickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(clickedPoint, out hit))
            {
                var selection = hit.transform;

                if (selection.CompareTag(selectableTag))
                {
                    if (selection.GetComponent<Renderer>().material.color != Color.red)
                    {
                        Select(selection);
                    }
                    else
                    {
                        Deselect(selection);
                    }


                }

            }

        }

        if (movableObject != null)
        {
            var movement = Camera.main.transform.right * Input.GetAxis("Horizontal_Obst");
            var verticalMovement = Input.GetAxis("Vertical_Obst");
            var temp = Camera.main.transform.forward;
            temp.y = 0;
            movement += temp.normalized * verticalMovement;
            movableObject.position += movement/4;
        }

      
    }




    void Select(Transform selection)
    {
        print("In Select!");
        if (movableObject != null)
        {
            movableObject.GetComponent<Renderer>().material.color = Color.yellow;
            movableObject = null;
        }

        movableObject = selection.GetComponent<Transform>();
        selection.GetComponent<Renderer>().material.color = Color.red;
    }

    void Deselect(Transform selection)
    {
        print("In deselect!");
        selection.GetComponent<Renderer>().material.color = Color.yellow;
        movableObject = null;

    }
}