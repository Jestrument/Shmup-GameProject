using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWawe" )]
public class EnemyWawe : ScriptableObject
{
	public GameObject enemy;
	public int enemyCount;
	public float rate;
	public int pooler;
	
	public float xMin;
	public float xMax;
		
	public float yMin;
	public float yMax;
	
	public bool xIsEmpty; 
	public float[] xOffset;
		
	public bool yIsEmpty;
	public float[] yOffset;
}
