using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;

    public float collisionRadius;

    public LayerMask whatIsDamagable;

    private Collider[] colliders;

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, collisionRadius, whatIsDamagable);

        foreach (Collider col in colliders)
        {
            Rigidbody[] rbs = col.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbs)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRadius);
    }
}
