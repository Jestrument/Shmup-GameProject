using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
	private TorpedoPooler torpedoPooler;
	private TBoomPooler tBoomPooler;
	
	private Vector2 moveDirection;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
	[SerializeField] EnemyHealth enemy;
	[SerializeField] EnemyGunHealth eGun;
	[SerializeField] EnemyBumber eBumber;
	
	[SerializeField] BossGunHealth bGun;
	[SerializeField] BossHealth boss;
	
	public int boomCount = 1;
	
	public bool didWeHit;
	
    void Start()
    {
        torpedoPooler = transform.parent.GetComponent<TorpedoPooler>();
		tBoomPooler = GameObject.FindWithTag("TBoomPooler").GetComponent<TBoomPooler>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyTorpedoAfterTime());
    }
	
	IEnumerator DestroyTorpedoAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		for(int i = 0; i < boomCount; i++)
		{
			float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
			float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
			Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
			Vector2 tDir = (tMoveVector - transform.position).normalized;
			GameObject g = tBoomPooler.GetObject();
			g.transform.position = gameObject.transform.position;
			g.transform.rotation = gameObject.transform.rotation;
			g.SetActive(true);
			g.GetComponent<TBoom>().SetMoveDirection(tDir);
			g.GetComponent<Animator>().PlayInFixedTime("Explode");
		}
		
		switch(didWeHit)
		{
			case true:
			break;
			
			case false:
			torpedoPooler.ReturnObject(gameObject);
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
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			torpedoPooler.ReturnObject(gameObject);
			break;
			
			case "Enemy":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			enemy = other.gameObject.GetComponent<EnemyHealth>();
			enemy.TakeDamage(10);
			torpedoPooler.ReturnObject(gameObject);
			break;
			
			case "Gun":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			eGun = other.gameObject.GetComponent<EnemyGunHealth>();
			eGun.TakeDamage(10);
			torpedoPooler.ReturnObject(gameObject);
			break;
			
			case "Bumber":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			eBumber = other.gameObject.GetComponent<EnemyBumber>();
			eBumber.TakeDamage(10);
			torpedoPooler.ReturnObject(gameObject);
			break;
			
			case "BossGun":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			bGun = other.gameObject.GetComponent<BossGunHealth>();
			bGun.TakeDamage(5);
			torpedoPooler.ReturnObject(gameObject);
			break;

			case "Boss":
			switch(didWeHit)
			{
				case true:
				break;
			
				case false:
				didWeHit = true;
				for(int i = 0; i < boomCount; i++)
				{
					float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
					float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
					Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
					Vector2 tDir = (tMoveVector - transform.position).normalized;
					GameObject g = tBoomPooler.GetObject();
					g.transform.position = gameObject.transform.position;
					g.transform.rotation = gameObject.transform.rotation;
					g.SetActive(true);
					g.GetComponent<TBoom>().SetMoveDirection(tDir);
					g.GetComponent<Animator>().PlayInFixedTime("Explode");
				}
				break;
			}
			boss = other.gameObject.GetComponent<BossHealth>();
			boss.TakeDamage(5);
			torpedoPooler.ReturnObject(gameObject);
			break;
		}
	}
}