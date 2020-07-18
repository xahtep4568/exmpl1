using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CreatingEnemies : MonoBehaviour
{

    [SerializeField]private GameObject[] enemy;
    private float timeSpawnWave = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        int pos_X = Random.Range(-5, 5);
        if (timeSpawnWave <= 0)
        {
            StartCoroutine(WaveSpawn(pos_X));
            timeSpawnWave = 6f;
        }
        timeSpawnWave -= Time.deltaTime;
	}

    IEnumerator WaveSpawn(int posX)
    {
        var SetEnemy = Random.Range(0, enemy.Length);
        var Direction = Random.Range(0, enemy.Length);
        var Amplitude = Random.Range(3, 6);
        var countSpawnEnemies = Random.Range(5, 10);
        for (int i = 0; i < countSpawnEnemies; i++)
        {
            var EnemyPref = Instantiate(enemy[SetEnemy], new Vector3(posX, 6, 0), Quaternion.identity) as GameObject;
            EnemyPref.GetComponent<Enemy>().SetModel(Direction,Amplitude);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
