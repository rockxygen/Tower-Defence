using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;
    public float explosionRange = 0f;


    public float speed = 70f;
    public int damage = 20;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject impactInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactInstance, 5f);

        if(explosionRange > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        //Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Debug.Log("Hit Enemy");
        Enemy e = enemy.GetComponent<Enemy>();
        
        if(e != null)
        {
            e.TakeDamage(damage);
            Debug.Log("test");
        }

        //Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
