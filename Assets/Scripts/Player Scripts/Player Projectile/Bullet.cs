using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private BulletPooler bullets;
	
	private Vector2 moveDirection;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
	public Collider2D[] colliderType;
	public Collider2D currentCollider;
	
	public bool didWeHit;
	public int damage;
	
	//Boom Stuff
	private GameObject empty; 
	private BoomPooler boomPooler;
	private Boom boom;
	
	public bool gGunIsOn = false;
	
	public int boomCollider = 1;
	
	public int boomCount = 6;
	
	public int boomDamage;
	public float boomForce = 10.0f;
	public float boomDistance = 1.0f;
	
	public SpriteRenderer boomRender;
	
	
	[SerializeField] private float boomStartAngle = 0f;
	[SerializeField] private float boomEndAngle = 360f;
	
	//Weapon effcect checks
	public bool piercingOn;
	public bool breakerOn;
	
	//damage Stuff
	[SerializeField] EnemyHealth enemy;
	[SerializeField] EnemyGunHealth eGun;
	
	private void Start()
	{
		bullets = transform.parent.GetComponent<BulletPooler>();
		empty = GameObject.FindWithTag("BoomPooler");
		boomPooler = empty.GetComponent<BoomPooler>();
	}
	
    private void OnEnable()
    {
		didWeHit = false;
        StartCoroutine(DestroyBulletAfterTime());
    }
	
	IEnumerator DestroyBulletAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		
		switch(gGunIsOn)
		{
			case true:
			float boomAngleStep = (boomEndAngle - boomStartAngle) /boomCount;
			float boomAngle = boomStartAngle;
		
			for(int x = 0; x < boomCount; x++)
			{
				float boomDirX = transform.position.x + Mathf.Sin((boomAngle * Mathf.PI) / 180f);
				float boomDirY = transform.position.y + Mathf.Cos((boomAngle * Mathf.PI) / 180f);
				Vector3 boomMoveVector = new Vector3(boomDirX, boomDirY, 0);
				Vector2 boomDir =(boomMoveVector - transform.position).normalized;
				GameObject b = boomPooler.GetObject();
				b.transform.position = transform.position;
				b.transform.rotation = transform.rotation;
				b.SetActive(true);
				boom = b.GetComponent<Boom>();
				boom.speed = boomForce;
				boom.lifeTime = boomDistance;
				boom.SwitchColliders(boomCollider);
				boom.SetMoveDirection(boomDir);
				boomAngle += boomAngleStep;
			}
			break;
			
			case false:
			break;
		}
		
		switch(didWeHit)
		{
			case true:
			break;
			
			case false:
			bullets.ReturnObject(gameObject);
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
			currentCollider = colliderType[amount-1];
			currentCollider.enabled = true;
			break;
			
			case 2:
			ResetColliders();
			currentCollider = colliderType[amount-1];
			currentCollider.enabled = true;
			break;
			
			case 3:
			ResetColliders();
			currentCollider = colliderType[amount-1];
			currentCollider.enabled = true;
			break;
			
			case 4:
			ResetColliders();
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
				bullets.ReturnObject(gameObject);
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
				switch(gGunIsOn)
				{
					case true:
					float boomAngleStep = (boomEndAngle - boomStartAngle) /boomCount;
					float boomAngle = boomStartAngle;
		
					for(int x = 0; x < boomCount; x++)
					{
						float boomDirX = transform.position.x + Mathf.Sin((boomAngle * Mathf.PI) / 180f);
						float boomDirY = transform.position.y + Mathf.Cos((boomAngle * Mathf.PI) / 180f);
						Vector3 boomMoveVector = new Vector3(boomDirX, boomDirY, 0);
						Vector2 boomDir =(boomMoveVector - transform.position).normalized;
						GameObject b = boomPooler.GetObject();
						b.transform.position = transform.position;
						b.transform.rotation = transform.rotation;
						b.SetActive(true);
						boom = b.GetComponent<Boom>();
						boom.speed = boomForce;
						boom.lifeTime = boomDistance;
						boom.SwitchColliders(boomCollider);
						boom.SetMoveDirection(boomDir);
						boomAngle += boomAngleStep;
					}
					break;
			
					case false:
					break;
				}
				bullets.ReturnObject(gameObject);
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
				switch(gGunIsOn)
				{
					case true:
					float boomAngleStep = (boomEndAngle - boomStartAngle) /boomCount;
					float boomAngle = boomStartAngle;
		
					for(int x = 0; x < boomCount; x++)
					{
						float boomDirX = transform.position.x + Mathf.Sin((boomAngle * Mathf.PI) / 180f);
						float boomDirY = transform.position.y + Mathf.Cos((boomAngle * Mathf.PI) / 180f);
						Vector3 boomMoveVector = new Vector3(boomDirX, boomDirY, 0);
						Vector2 boomDir =(boomMoveVector - transform.position).normalized;
						GameObject b = boomPooler.GetObject();
						b.transform.position = transform.position;
						b.transform.rotation = transform.rotation;
						b.SetActive(true);
						boom = b.GetComponent<Boom>();
						boom.speed = boomForce;
						boom.lifeTime = boomDistance;
						boom.SwitchColliders(boomCollider);
						boom.SetMoveDirection(boomDir);
						boomAngle += boomAngleStep;
					}
					break;
			
					case false:
					break;
				}
				
				switch(piercingOn)
				{
					case true:
					break;
					
					case false:
					bullets.ReturnObject(gameObject);
					break;
				}
				eGun = other.gameObject.GetComponent<EnemyGunHealth>();
				eGun.TakeDamage(1);
				break;
			}
			break;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		switch(piercingOn)
		{
			case true:
			switch(other.tag)
			{
				case "Enemy":
				enemy = other.gameObject.GetComponent<EnemyHealth>();
				enemy.TakeDamage(1);
				
				break;
			
				case "Gun":
				eGun = other.gameObject.GetComponent<EnemyGunHealth>();
				eGun.TakeDamage(1);
				break;
			}
			break;
			
			case false:
			break;
		}
	}
}
