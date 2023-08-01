using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementX : MonoBehaviour
{
   EnemyPooler enemyPooler;
	
	float sinCenterY;
	public float amplitude;
	public float frequency;
	public float speed;
	
	public float xEndPos = -14f;
	
	public bool sinIsOn;
	public bool isEndDeath;
	public bool isMinus;
	
	void OnEnable()
	{
		sinCenterY = transform.position.y;
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
		
		switch(sinIsOn)
		{
			case true:
			float sin = Mathf.Sin(Time.time * frequency) * amplitude;
			pos.x = sinCenterY + sin;
			break;
			
			case false:
			pos.x -= speed * Time.fixedDeltaTime;
			break;
		}
		
		
		
		switch(isEndDeath)
		{
			case true:
			switch(isMinus)
			{
				case true:
				if( transform.position.x >= xEndPos)
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
				if( transform.position.x <= xEndPos)
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
			if(transform.position.x <= xEndPos)
			{
				speed = 0f;
			}
			break;
		}
		transform.position = pos;
    }
}
