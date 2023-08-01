using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWawe : MonoBehaviour
{
	public enum SpawnState { Spawning, Waiting, Counting, Finished}
	
	[SerializeField] EnemyPooler enemyPooler;
	[SerializeField] EnemyPooler bPooler;
	[SerializeField] EnemyPooler gPooler;
	[SerializeField] EnemyPooler hPooler;
	[SerializeField] EnemyPooler lPooler;
	[SerializeField] EnemyPooler mPooler;
	[SerializeField] EnemyPooler sPooler;
	[SerializeField] EnemyPooler xMinusPooler;
	[SerializeField] EnemyPooler xPooler;
	[SerializeField] EnemyPooler yPooler;
	
	//EnemyWawes
	[SerializeField] Wawe waweB;
	[SerializeField] Wawe waweG;
	[SerializeField] Wawe waweH;
	[SerializeField] Wawe waweL;
	[SerializeField] Wawe waweM;
	[SerializeField] Wawe waweS;
	[SerializeField] Wawe waweXMinus;
	[SerializeField] Wawe waweX;
	[SerializeField] Wawe waweY;
	
	[System.Serializable]
	public class Wawe 
	{
		public EnemyWawe enemyData;
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
		wawes = new Wawe[Random.Range(1,5)];
		for(int i = 0; i < wawes.Length; i++)
		{
			int waweNumber = Random.Range(0,8);
			switch(waweNumber)
			{
				case 0:
				wawes[i] = waweB;
				break;
				
				case 1:
				wawes[i] = waweG;
				break;
				
				case 2:
				wawes[i] = waweH;
				break;
				
				case 3:
				wawes[i] = waweL;
				break;
				
				case 4:
				wawes[i] = waweM;
				break;
				
				case 5:
				wawes[i] = waweS;
				break;
				
				case 6:
				wawes[i] = waweXMinus;
				break;
				
				case 7:
				wawes[i] = waweX;
				break;
				
				case 8:
				wawes[i] = waweY;
				break;
			}
		}
    }

    void Update()
    {
		if(state == SpawnState.Waiting)
		{
			if(!EnemyIsAlive())
			{
				WaweIsCompleted();
			}
			else 
			{
				return;
			}
		}
		
		if(state == SpawnState.Finished)
		{
			return;
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
	
	void WaweIsCompleted()
	{
		state = SpawnState.Counting;
		timer = timeBetweenWawes;
		if(nextWawe + 1 > wawes.Length - 1)
		{
			state = SpawnState.Finished;
		}
		else
		{
			nextWawe++;
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
		_wawe.enemyData.enemy.transform.position = Vector3.zero;
		state = SpawnState.Spawning;
		
		switch(_wawe.enemyData.pooler)
		{
			case 1:
			enemyPooler = bPooler;
			break;
			
			case 2:
			enemyPooler = gPooler;
			break;
			
			case 3:
			enemyPooler = hPooler;
			break;
			
			case 4:
			enemyPooler = lPooler;
			break;
			
			case 5:
			enemyPooler = mPooler;
			break;
			
			case 6:
			enemyPooler = sPooler;
			break;
			
			case 7:
			enemyPooler = xMinusPooler;
			break;
			
			case 8:
			enemyPooler = xPooler;
			break;
			
			case 9:
			enemyPooler = yPooler;
			break;
		}
		
		float xPos = Random.Range(_wawe.enemyData.xMin,_wawe.enemyData.xMax);
		
		float yPos = Random.Range(_wawe.enemyData.yMin,_wawe.enemyData.yMax);
		
		float x;
		float y;
		Vector3[] spawnpoint = new Vector3[_wawe.enemyData.enemyCount];
		
		for(int i = 0; i < _wawe.enemyData.enemyCount; i++)
		{
			switch(_wawe.enemyData.xIsEmpty)
			{
				case false:
				x = xPos + _wawe.enemyData.xOffset[i];
				break;
			
				case true:
				x = xPos;
				break;
			}
				
			switch(_wawe.enemyData.yIsEmpty)
			{
				case false:
				y = yPos + _wawe.enemyData.yOffset[i];
				break;
				
				case true:
				y = yPos;
				break;
			}
			spawnpoint[i] = new Vector3(x, y, 0);
			_wawe.enemyData.enemy.transform.position = spawnpoint[i];
			SpawnEnemy(_wawe.enemyData.enemy);
			yield return new WaitForSeconds(_wawe.enemyData.rate);
		}
		
		state = SpawnState.Waiting;
		
		yield break;
	}
	
	void SpawnEnemy(GameObject _enemy)
	{
		GameObject g = enemyPooler.GetObject();
		g.transform.position = _enemy.transform.position;
		g.transform.rotation = _enemy.transform.rotation;
		EnemyGunPoint[] gunpoints = g.GetComponentsInChildren<EnemyGunPoint>();
		foreach(EnemyGunPoint gunpoint in gunpoints)
		{
			gunpoint.canShoot= true;
		}
		g.SetActive(true);
	}
}
