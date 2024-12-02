using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _mTower;
    public float speed;
    public int damage;
    public int health;

    void Start()
    {
        _mTower = GameObject.FindWithTag("MagicalTower").transform;
    }

    private void Update()
    {
        MoveTowardsTower();
    }

    private void MoveTowardsTower()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mTower.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MagicalTower"))
        {
            Debug.Log("enter");
            MagicalTowerController towerController=other.gameObject.GetComponent<MagicalTowerController>();
            towerController.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
