using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Adversary : MonoBehaviour
{


    public string selectableTag = "selectedAdversary";
    public string layer = "ground";
    public bool selected;
    private NavMeshAgent adversary = null;

    // Start is called before the first frame update
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
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
                else if (selection.CompareTag(layer))
                {
                    if (selected)
                    {
                        move(hit);

                    }

                }

            }

        }

    }

    void Deselect(Transform selection)
    {
        print("In Deselect");
        selection.GetComponent<Renderer>().material.color = Color.white;
        adversary = null;
        selected = false;

    }

    void Select(Transform selection)
    {

        var selectedNavMeshAgent = selection.GetComponent<NavMeshAgent>();
        selection.GetComponent<Renderer>().material.color = Color.red;
        selected = true;
        adversary = selectedNavMeshAgent;
    }


    void move(RaycastHit positionToMove)
    { 
        Vector3 agentDestination = positionToMove.point + Random.insideUnitSphere * 0.5f;
        agentDestination.y = 0;
        adversary.SetDestination(agentDestination);
        
    }

}
