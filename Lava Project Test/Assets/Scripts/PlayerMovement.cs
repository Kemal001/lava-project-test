using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    public GameObject clickIndicator;

    private NavMeshAgent agent;

    private void Awake() => agent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        ClickToMove();
    }

    private void ClickToMove()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;

            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                agent.SetDestination(hit.point);

                Instantiate(clickIndicator, hit.point + new Vector3(0f, 0.2f, 0f), clickIndicator.transform.rotation);
            }
        }
    }
}
