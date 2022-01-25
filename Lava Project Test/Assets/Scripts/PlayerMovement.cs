using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ClickToMove();
    }

    private void ClickToMove()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            RaycastHit hit;

            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
