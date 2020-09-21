using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public LayerMask clickable;
   
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray toClickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit infoForRay;

            if(Physics.Raycast(toClickedPoint, out infoForRay, 100, clickable))
            {
                agent.SetDestination(infoForRay.point);
            }
            
        }
    }
}
