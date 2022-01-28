using UnityEngine;
using UnityEngine.AI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public Transform groundCheck;
    public float radius;
    public LayerMask whatIsShootingArea;

    private NavMeshAgent agent;

    public float bulletSpeed;
    public float fireRate;
    private float lastShot = 0.0f;

    private bool onShootingArea;

    private void Awake() => agent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        onShootingArea = Physics.CheckSphere(groundCheck.position, radius, whatIsShootingArea);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
        {
            RotateTo(hit);
            Shoot(hit);
        }
    }

    private void RotateTo(RaycastHit hit)
    {
        if (onShootingArea)
        {
            Vector3 lookPos = hit.point - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 100 * Time.deltaTime);
        }
    }

    private void Shoot(RaycastHit hit)
    {
        if (onShootingArea && Input.GetKey(KeyCode.Mouse0) && Time.time > fireRate + lastShot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce((hit.point - firePoint.position) * bulletSpeed, ForceMode.Impulse);

            lastShot = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
