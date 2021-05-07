using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public float rotateSpeed = 10f;

    public GameObject bulletPF;
    public Transform fireCreatePoint;

    public Transform TurretRotate;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5F); 
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float enemyToDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(enemyToDistance < shortDistance)
            {
                shortDistance = enemyToDistance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion followRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(TurretRotate.rotation, followRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        TurretRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        #region Enemy Fire
        if (fireCountDown <= 0f)
        {
            Fire();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
        #endregion
    }

    void Fire()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPF, fireCreatePoint.position, fireCreatePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
