using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementY : MonoBehaviour
{
	EnemyPooler enemyPooler;
	
	float sinCenterX;
	public float amplitude;
	public float frequency;
	public float speed;
	
	public float yEndPos = -8;
	
	public bool cosIsOn;
	public bool isEndDeath;
	public bool isMinus;
	
	void OnEnable()
	{
		sinCenterX = transform.position.x;
    }

	
    void Start()
    {
        enemyPooler = transform.parent.GetComponent<EnemyPooler>();
		
	}

    void Update()
    {
      
    }
	
	void FixedUpdate()
	{
		Vector2 pos = transform.position;
		
		switch(cosIsOn)
		{
			case true:
			float cos = Mathf.Cos(Time.time * frequency) * amplitude;
			pos.x = sinCenterX + cos;
			pos.y -= speed * Time.fixedDeltaTime;
			break;
			
			case false:
			pos.y -= speed * Time.fixedDeltaTime;
			break;
		}
		
		
		
		switch(isEndDeath)
		{
			case true:
			switch(isMinus)
			{
				case true:
				if( transform.position.y >= yEndPos)
				{	
					EnemyHealth healthData = GetComponentInChildren<EnemyHealth>();
					healthData.health = healthData.maxHealth;
				
					EnemyGunHealth[] gunData = GetComponentsInChildren<EnemyGunHealth>();
					foreach(EnemyGunHealth gunHealth in gunData)
					{
						gunHealth.Reset();  
					}
				
					enemyPooler.ReturnObject(gameObject);
				}
				break;
				
				case false:
				if( transform.position.y <= yEndPos)
				{	
					EnemyHealth healthData = GetComponentInChildren<EnemyHealth>();
					healthData.health = healthData.maxHealth;
				
					EnemyGunHealth[] gunData = GetComponentsInChildren<EnemyGunHealth>();
					foreach(EnemyGunHealth gunHealth in gunData)
					{
						gunHealth.Reset();  
					}
				
					enemyPooler.ReturnObject(gameObject);
				}
				break;
			}
			break;
			
			case false:
			if(transform.position.y <= yEndPos)
			{
				speed = 0f;
			}
			break;
		}
		transform.position = pos;
	}
}
