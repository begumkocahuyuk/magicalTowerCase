using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpell : MonoBehaviour
{
    public GameObject fireballPrefab;  
    public GameObject barragePrefab; 
    public Transform towerTransform;
    public float fireballSpeed = 10f;
    public float barrageSpeed = 50f;
    public float fireballDamage = 20f;
    public float barrageDamage = 5f;

    public float fireballDownTime = 5f;
    public float barrageDownTime = 1f;

    public float fireballTime;
    public float barrageTime;

    private void Start()
    {
        towerTransform = transform;
    }
    void Update()
    {
        barrageTime += Time.deltaTime;
        fireballTime += Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.B))
        {
            if(barrageTime >= barrageDownTime)
            {
                barrageTime = 0f;
                BarrageAction();
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (fireballTime >= fireballDownTime)
            {
                fireballTime = 0f;
                FireballAction();
            }
        }
    }

    public void BarrageAction()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject barrage = Instantiate(barragePrefab, towerTransform.position, Quaternion.identity);
            Rigidbody rb = barrage.GetComponent<Rigidbody>();
            Vector3 directionToEnemy = (enemy.transform.position - barrage.transform.position).normalized;
            rb.velocity = directionToEnemy * barrageSpeed;

            enemy.GetComponent<EnemyController>().TakeDamage(barrageDamage);
            
        }
    }

    public void FireballAction()
    {
        GameObject fireball = Instantiate(fireballPrefab, towerTransform.position, Quaternion.identity);
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        rb.velocity = randomDirection * fireballSpeed;

        Fireball fireballScript = fireball.GetComponent<Fireball>();
        fireballScript.damage = fireballDamage;
    }


}
