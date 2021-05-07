using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Values")]
    public float speed = 10f;
    public int enemyHealth = 100;
    public int gain = 50;

    [Header("Objects")]
    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    void Start()
    {
        target = Waypoints.points[wavePointIndex];
    }

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;

        Debug.Log("health " + enemyHealth);

        if(enemyHealth <= 0)
        {
            Debug.Log("Die");
            Die();
        }
    }

    void Die()
    {
        PlayerInfo.Money += gain;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log(PlayerInfo.Money);
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.6f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavePointIndex >= Waypoints.points.Length - 1)
        {
            //Destroy(gameObject);
            EndPath();
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerInfo.Lives--;
        Destroy(gameObject);
    }
}
