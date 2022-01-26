using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Move", agent.velocity.magnitude > 0.1f);
    }
}
