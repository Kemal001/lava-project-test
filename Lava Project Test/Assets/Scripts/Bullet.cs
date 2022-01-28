using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Effects")]
    public GameObject impactEffect;

    [Header("Bullet Force")]
    public float forceAmount;
    public float explosionRadius;

    [Header("Collision Check")]
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
            col.transform.parent.root.SendMessage("ActivateRagdoll");

            Instantiate(impactEffect, transform.position, Quaternion.identity);

            Rigidbody[] rbs = col.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbs)
            {
                //rb.AddExplosionForce(forceAmount, transform.position, explosionRadius);
                rb.AddForce((rb.position - transform.position) * forceAmount, ForceMode.Impulse);
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
