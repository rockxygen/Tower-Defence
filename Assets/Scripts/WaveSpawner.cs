using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemy;
    public Transform createPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int enemyNumber = 0;

    public Text enemyCountTimer;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnEnemy());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        enemyCountTimer.text = string.Format("{0:00.00}", countdown);

        //enemyCountTimer.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnEnemy()
    {
        enemyNumber++;
        for (int i = 0; i < enemyNumber; i++)
        {
            CreateEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void CreateEnemy()
    {
        Instantiate(enemy, createPoint.position, createPoint.rotation);
    }
}
