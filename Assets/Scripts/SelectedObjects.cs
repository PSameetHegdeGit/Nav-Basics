﻿using System.Collections;
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

    private Vector3 targetPosition;

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
              
            }

        }

        if (Input.GetMouseButtonUp(1))
        {

            Ray clickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(clickedPoint, out hit))
            {
                move(hit, selectedAgents);

            }
        }

   

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            DeselectAll();
        }


        StartCoroutine("haltAgents");
    
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
            Vector3 agentDestination = positionToMove.point + Random.insideUnitSphere * 0.02f;
            agentDestination.y = 0;
            agent.SetDestination(agentDestination);
        }

        targetPosition = positionToMove.point;


    }

    void haltAgents()
    {


        if(targetPosition != null)
        {

            foreach(NavMeshAgent agent in selectedAgents)
            {
               if(Vector3.Distance(targetPosition, agent.transform.position) <= 3f)
                {
                    agent.velocity = Vector3.zero;

                }
            }


        }




    }



}
