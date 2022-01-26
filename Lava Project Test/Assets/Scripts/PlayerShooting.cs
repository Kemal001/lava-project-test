using UnityEngine;
using UnityEngine.AI;

public class PlayerShooting : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake() => agent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
        {
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 100 * Time.deltaTime);
        }
    }
}
