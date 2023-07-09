using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPooler : MonoBehaviour
{
	[SerializeField] private Boom boomData;
	
	//Explosion prefab
	[SerializeField] private GameObject explosion;
	
	//Explosion pool
	[SerializeField] private int poolSize;
	[SerializeField] private bool expandable;
	private List<GameObject> freeList;
	private List<GameObject> usedList;
	
	//How fast does the explosion move and how far does it move
	public int damage;
	public float force;
	public float distance;
	public int colliderType = 1;
	
    private void Awake()
    {
		freeList = new List<GameObject>();
		usedList = new List<GameObject>();
		
		for(int i = 0; i < poolSize; i++)
		{
			GenerateNewObject();
		}
    }

   //Gets explosions from the pool
	public GameObject GetObject()
	{
		int totalFree = freeList.Count;
		if(totalFree == 0 && !expandable)return null;
		
		else if(totalFree == 0) GenerateNewObject();
		
		GameObject g = freeList[totalFree-1];
		boomData = g.transform.GetComponent<Boom>();
		boomData.speed = force;
		boomData.lifeTime = distance;
		boomData.SwitchColliders(colliderType);
		freeList.RemoveAt(totalFree-1);
		usedList.Add(g);
		return g;
	}
	
	//Return explosions to the pool
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
        GameObject g = Instantiate(explosion);
		g.transform.parent= transform;
		g.SetActive(false);
		freeList.Add(g);
    }
}
