using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWawe : MonoBehaviour
{
	public enum SpawnState { Spawning, Waiting, Counting, Finished}
	
	[SerializeField] EnemyPooler enemyPooler;
	
	[System.Serializable]
	public class Wawe 
	{
		public string name;
		public GameObject enemy;
		public int enemyCount;
		public float rate;
		
		public Vector3[] spawnPoints;
	}
	
	public Wawe[] wawes;
	public int nextWawe;
	
	public float timeBetweenWawes = 5f;
	public float timer;
	
	private float searchTimer = 1f;
	
	private SpawnState state = SpawnState.Counting;
	
    void Start()
    {
        timer = timeBetweenWawes;
    }

    void Update()
    {
		if(state == SpawnState.Waiting)
		{
			if(!EnemyIsAlive())
			{
				
			}
		}
		
        if(timer <= 0)
		{
			if(state != SpawnState.Spawning)
			{
				StartCoroutine(SpawnWawe(wawes[nextWawe]));
			}
			else
			{
				return;
			}
		}
		else
		{
			timer -= Time.deltaTime;
		}
    }
	
	bool EnemyIsAlive()
	{
		searchTimer -= Time.deltaTime;
		
		if(searchTimer <= 0f)
		{
			searchTimer = 1f;
			if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
			{
				return false;
			}
		}
		
		return true;
	}
	
	IEnumerator SpawnWawe(Wawe _wawe)
	{
		state = SpawnState.Spawning;
		
		
		for(int i = 0; i < _wawe.enemyCount; i++)
		{
			_wawe.enemy.transform.position = _wawe.spawnPoints[i];
			SpawnEnemy(_wawe.enemy);
			
			yield return new WaitForSeconds(1f / _wawe.rate);
		}
		
		state = SpawnState.Waiting;
		
		yield break;
	}
	
	void SpawnEnemy(GameObject _enemy)
	{
		GameObject g = enemyPooler.GetObject();
		g = _enemy;
		g.transform.position = _enemy.transform.position;
		g.transform.rotation = _enemy.transform.rotation;
		g.SetActive(true);
	}
}
