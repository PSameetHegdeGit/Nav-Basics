using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SelectedObjects : MonoBehaviour
{
    public ArrayList selectedAgents;
    private Adversary adversary;
    public GameObject adversaryParent;

    public string selectableTag = "selected";
    public string layer = "ground";

    void Start()
    {

        selectedAgents = new ArrayList();
        adversary = adversaryParent.GetComponent<Adversary>();
    }

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
                else if (selection.CompareTag(layer))
                {

                    move(hit, selectedAgents);
                }

            }

        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            DeselectAll();
        }

        StartCoroutine(haltAgents());
    }


    void Select(Transform selection)
    {
        if (selectedAgents.Count == 0)
        {
            if(adversary.adversary != null)
            {
                adversary.adversary.GetComponent<Renderer>().material.color = Color.yellow;
                adversary.adversary = null;
            }
        }

        var selectedNavMeshAgent = selection.GetComponent<NavMeshAgent>();
        selection.GetComponent<Renderer>().material.color = Color.red;
        selectedAgents.Add(selectedNavMeshAgent);
    }


    void Deselect(Transform selection)
    {
        print("In Deselect");
        var deselectedNavMeshAgent = selection.GetComponent<NavMeshAgent>();
        selection.GetComponent<Renderer>().material.color = Color.white;

        selectedAgents.Remove(deselectedNavMeshAgent);

    }

    public void DeselectAll()
    {

        print("in escape");


        foreach (NavMeshAgent agent in selectedAgents)
        {

            agent.GetComponent<Renderer>().material.color = Color.white;
        }



        selectedAgents.Clear();
    }


    void move(RaycastHit positionToMove, ArrayList agents)
    {
        foreach (NavMeshAgent agent in agents)
        {
            Vector3 agentDestination = positionToMove.point;
            agentDestination.y = 0;
            agent.SetDestination(agentDestination);
        }

     

    }



    IEnumerator haltAgents()
    {
        if (selectedAgents.Count > 0)
        {
            NavMeshAgent first;
            while (true)
            {
                yield return null;
                foreach (NavMeshAgent agent in selectedAgents)
                {
                    if (agent.velocity == Vector3.zero)
                    {
                        first = agent;
                        break;
                    }
                }

            
            }

            while (true)
            {
                yield return null;
                foreach(NavMeshAgent agent in selectedAgents)
                {
                    if(Vector3.Distance(agent.transform.position, first.transform.position) <= 10f)
                    {
                        agent.velocity = Vector3.zero;
                    }
                }

                var count = selectedAgents.Count;

                foreach(NavMeshAgent agent in selectedAgents)
                {
                    if(agent.velocity == Vector3.zero)
                    {
                        count--;
                    }
                }
                if(count == 0)
                {
                    break;
                }
            }

        }
         
    }






}
