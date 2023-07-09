using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
	[SerializeField] private Bullet bulletData;
	
	//Bullet prefab
	[SerializeField] private GameObject bullet;
	
	//Bullet pool
	[SerializeField] private int poolSize;
	[SerializeField] private bool expandable;
	private List<GameObject> freeList;
	private List<GameObject> usedList;
	
	//Changeable values for bullets
	public int damage;
	public float force = 10.0f;
	public float distance = 1.0f;
	public int colliderType = 4;
	
    private void Awake()
    {
		freeList = new List<GameObject>();
		usedList = new List<GameObject>();
		
		for(int i = 0; i < poolSize; i++)
		{
			GenerateNewObject();
		}
    }
	
	//Gets bullets from the pool
	public GameObject GetObject()
	{
		int totalFree = freeList.Count;
		if(totalFree == 0 && !expandable)return null;
		
		else if(totalFree == 0) GenerateNewObject();
		
		GameObject g = freeList[totalFree-1];
		bulletData = g.transform.GetComponent<Bullet>();
		bulletData.speed = force;
		bulletData.lifeTime = distance;
		bulletData.SwitchColliders(colliderType);
		freeList.RemoveAt(totalFree-1);
		usedList.Add(g);
		return g;
	}
	
	//Return Bullets to the pool
	public void ReturnObject(GameObject obj)
	{
		Debug.Assert(usedList.Contains(obj));
		obj.SetActive(false);
		usedList.Remove(obj);
		freeList.Add(obj);
	}
	
	
	//Creates new game objects
    private void GenerateNewObject()
    {
        GameObject g = Instantiate(bullet);
		g.transform.parent= transform;
		g.SetActive(false);
		freeList.Add(g);
    }
}
