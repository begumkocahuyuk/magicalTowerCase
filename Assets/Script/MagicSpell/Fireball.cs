using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float damage;
    public float explosionRadius = 10f;
    public float explosionForce = 30f;

    void OnCollisionEnter(Collision collision)
    {
        // Patlama iþlemi
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in colliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
