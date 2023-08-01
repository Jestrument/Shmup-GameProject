using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPoint : MonoBehaviour
{
	[SerializeField] private PlayerShoot pShoot;
	[SerializeField] private BulletPooler bulletPool;
	[SerializeField] private Bullet bullet;

	public SpriteRenderer render;
	public Sprite bulletImage;
	public Sprite burst;
	public Sprite grenade;
	public Sprite laser;
	public Sprite machineGun;
	public Sprite split;
	
	public int bulletCount = 1;
	private int colliderType = 4;
	
	public int damage;
	public float force = 10.0f;
	public float distance = 1.0f;
	
	[SerializeField] private float startAngle;
	[SerializeField] private float endAngle;
	[SerializeField] private float startPosition;
	[SerializeField] private float endPosition;
	
	[SerializeField] private float startAngleChanged;
	[SerializeField] private float endAngleChanged; 
	[SerializeField] private float startPositionChanged;
	[SerializeField] private float endPositionChanged;
	
	//Grenade data
	public bool isGGunOn = false;
	public int boomCollider = 1;
	
	public int boomCount = 6;
	
	public int boomDamage;
	public float boomForce = 3.0f;
	public float boomDistance = 0.05f;
	
	[SerializeField] public BoomPooler boomPool;
	[SerializeField] public Boom boom;
	
	[SerializeField] private TorpedoPooler torpedoPool;
	[SerializeField] private Torpedo tData;
	
	public int tCount = 1;
	public bool piercingOn;
	public bool breakerOn;
	
	private void Update()
	{
		startAngle = startAngleChanged;
		endAngle = endAngleChanged;
		startPosition = startPositionChanged;
		
		endPosition = endPositionChanged;
	}
	
	public void Shoot()
	{	
		float angleStep = (endAngle - startAngle) /bulletCount;
		float angle = startAngle;
		
		float xPosStep = (endPosition - startPosition) /bulletCount;
		float xPos = startPosition;
		
		for(int i = 0; i < bulletCount; i++)
		{
			float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
			float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
			Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
			Vector2 bulDir = (bulMoveVector - transform.position).normalized;
			GameObject g = bulletPool.GetObject();
			g.transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
			g.transform.rotation = transform.rotation;		
			render = g.transform.GetComponent<SpriteRenderer>(); 
			render.sprite = bulletImage;
			g.SetActive(true);
			bullet = g.GetComponent<Bullet>();
			bullet.speed = force;
			bullet.lifeTime = distance;
			bullet.SwitchColliders(colliderType);
			bullet.SetMoveDirection(bulDir);
			bullet.gGunIsOn = isGGunOn;
			bullet.boomCount = boomCount;
			bullet.boomForce = boomForce;
			bullet.boomDistance = boomDistance;
			angle += angleStep;
			xPos += xPosStep;
		}
	}
	
	public void FireTorpedo()
	{		
		for(int l =0; l< tCount; l++)
		{
			float tDirX = transform.position.x + Mathf.Sin((0 * Mathf.PI) / 180f);
			float tDirY = transform.position.y + Mathf.Cos((0 * Mathf.PI) / 180f);
			Vector3 tMoveVector = new Vector3(tDirX, tDirY, 0);
			Vector2 tDir = (tMoveVector - transform.position).normalized;
			GameObject g = torpedoPool.GetObject();
			g.transform.position = transform.position;
			g.transform.rotation = transform.rotation;
			g.SetActive(true);
			tData = g.GetComponent<Torpedo>();
			tData.SetMoveDirection(tDir);
		}
	}
	
	public void ChangeBulletType(string item)
	{
		switch(item)
		{	
			case "B1":
			bulletCount = 3;
			colliderType = 1;
			force = 7.0f;
			distance = 0.4f;
			startAngleChanged = -30.0f;
			endAngleChanged = 60.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			bulletImage = burst;

			isGGunOn = false;
			piercingOn = false;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.1f;
			break;
			
			case "B2":
			bulletCount = 3;
			force = 7.0f;
			distance = 0.4f;
			startAngleChanged = -30.0f;
			endAngleChanged = 60.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.1f;
			break;
			
			case "B3":
			bulletCount = 3;
			force = 7.0f;
			distance = 0.4f;
			startAngleChanged = -30.0f;
			endAngleChanged = 60.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.1f;
			break;
			
			case "G1":
			bulletCount = 1;
			colliderType = 2;
			force = 4.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;	
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;			
			bulletImage = grenade;
			
			isGGunOn = true;
			boomCount = 4;
			boomForce = 1.0f;
			boomDistance = 1f;
			boomCollider = 1;
			boomPool.force = boomForce;
			boomPool.distance = boomDistance;
			boomPool.colliderType = boomCollider;
			
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.5f;
			break;
			
			case "G2":
			bulletCount = 1;
			force = 4.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			boomCount = 6;
			boomForce = 1.0f;
			boomDistance = 1.0f;
			boomCollider = 1;
			boomPool.force = boomForce;
			boomPool.distance = boomDistance;
			boomPool.colliderType = boomCollider;
			
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.5f;
			break;
			
			case "G3":
			bulletCount = 1;
			force = 4.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			boomCount = 8;
			boomForce = 1.5f;
			boomDistance = 1.1f;
			boomCollider = 2;
			boomPool.force = boomForce;
			boomPool.distance = boomDistance;
			boomPool.colliderType = boomCollider;
			
			boomPool.force = boomForce;
			boomPool.distance = boomDistance;
			boomPool.colliderType = boomCollider;
			
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			
			pShoot.delay = 0.5f;
			break;
			
			case "L1":
			bulletCount = 1;
			colliderType = 3;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			bulletImage = laser;
			
			isGGunOn = false;
			piercingOn = true;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "L2":
			bulletCount = 1;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "L3":
			bulletCount = 1;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "M1":
			bulletCount = 1;
			colliderType = 4;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = 0.0f;
			endPositionChanged = 0.0f;
			bulletImage = machineGun;

			isGGunOn = false;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "M2":
			bulletCount = 2;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = -0.125f;
			endPositionChanged = 0.375f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "M3":
			bulletCount = 3;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = -0.125f;
			endAngleChanged = 0.375f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "S1":
			bulletCount = 2;
			colliderType = 3;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = -0.0f;
			endAngleChanged = 0.0f;
			startPositionChanged = -0.093f;
			endPositionChanged = 0.279f;
			bulletImage = split;
			
			isGGunOn = false;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "S2":
			bulletCount = 2;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
			
			case "S3":
			bulletCount = 2;
			force = 10.0f;
			distance = 1.0f;
			startAngleChanged = 0.0f;
			endAngleChanged = 0.0f;
			
			bulletPool.force = force;
			bulletPool.distance = distance;
			bulletPool.colliderType = colliderType;
			
			pShoot.delay = 0.0f;
			break;
		}
	}
}
