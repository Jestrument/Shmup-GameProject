using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
	private BoomPooler boomPooler;
	
	private Vector2 moveDirection;
	public int boomDamage;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
	public Collider2D[] colliderType;
	public Collider2D currentCollider;
	
	private string effect;
	[SerializeField] Animator brain;
	
	//damage Stuff
	public bool didWeHit;
	
	[SerializeField] EnemyHealth enemy;
	[SerializeField] EnemyGunHealth eGun;
	[SerializeField] EnemyBumber eBumber;
	
	[SerializeField] BossGunHealth bGun;
	[SerializeField] BossHealth boss;
	
    private void Start()
	{
		boomPooler = transform.parent.GetComponent<BoomPooler>();
	}
	
	private void OnEnable()
    {
		didWeHit = false;
		brain.PlayInFixedTime(effect);
        StartCoroutine(DestroyBoomAfterTime());
    }
	
	IEnumerator DestroyBoomAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		switch(didWeHit)
		{
			case true:
			break;
			
			case false:
			boomPooler.ReturnObject(gameObject);
			break;
		}
	}


    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
	
	public void SetMoveDirection(Vector2 dir)
	{
		moveDirection = dir;
	}
	
	public void SwitchColliders(int amount)
	{
		switch(amount)
		{
			case 1:
			ResetColliders();
			effect = "Bang";
			currentCollider = colliderType[amount-1];
			currentCollider.enabled = true;
			break;
			
			case 2:
			ResetColliders();
			effect = "Boom";
			currentCollider = colliderType[amount-1];
			currentCollider.enabled = true;
			break;
		}
	}

	private void ResetColliders()
	{
		foreach(Collider2D collider in colliderType)
		{
			collider.enabled = false;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.tag)
		{
			case "Gamebounds":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				boomPooler.ReturnObject(gameObject);
				break;
			}
			break;
			
			case "Enemy":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				enemy = other.gameObject.GetComponent<EnemyHealth>();
				enemy.TakeDamage(1);
				break;
			}
			break;
			
			case "Gun":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				eGun = other.gameObject.GetComponent<EnemyGunHealth>();
				eGun.TakeDamage(1);
				break;
			}
			break;
			
			case "Bumber":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				eBumber = other.gameObject.GetComponent<EnemyBumber>();
				eBumber.TakeDamage(1);
				boomPooler.ReturnObject(gameObject);
				break;
			}
			break;
			
			case "BossGun":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				bGun = other.gameObject.GetComponent<BossGunHealth>();
				bGun.TakeDamage(1);
				break;
			}
			break;
			
			
			case "Boss":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				boss = other.gameObject.GetComponent<BossHealth>();
				boss.TakeDamage(1);
				break;
			}
			break;
		}
	}
}
