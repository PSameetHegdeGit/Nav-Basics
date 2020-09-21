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
        print(Pause.setAgentsVelocity);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray toClickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit infoForRay;

            Pause.setAgentsVelocity = 0;

            if(Physics.Raycast(toClickedPoint, out infoForRay, 100, clickable))
            {
                Vector3 agentDestination = infoForRay.point + Random.insideUnitSphere * 0.5f;
                agentDestination.y = 0;
                print(agentDestination);
                agent.SetDestination(agentDestination);
           
            }
            
        }

        if (Pause.setAgentsVelocity == 0)
        {
            if (agent.velocity == Vector3.zero)
            {
                Pause.setAgentsVelocity = 1;
            }
        }
        else if (Pause.setAgentsVelocity == 1)
        {
            agent.velocity = Vector3.zero;
        }
    }
}
