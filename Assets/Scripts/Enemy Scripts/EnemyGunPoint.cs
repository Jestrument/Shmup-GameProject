using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunPoint : MonoBehaviour
{
	[SerializeField] private EnemyBulletPooler eBulletPool;
	[SerializeField] private EnemyBullet eBullet;
	
	public SpriteRenderer render;
	public Sprite bulletImage;
	
	public int bulletCount = 1;
	
	public float force = 10.0f;
	public float distance = 1.0f;
	public float delay;
	public float timer;
	public int colliderType;
	
	[SerializeField] private float startAngle;
	[SerializeField] private float endAngle;
	
	[SerializeField] private float startPosition;
	[SerializeField] private float endPosition;

	public bool canShoot = false;
	public bool gunIsDead;
	
	private void Start()
	{
		eBulletPool = GameObject.FindWithTag("EnemyBulletPooler").GetComponent<EnemyBulletPooler>();
	}
	
	private void Update()
	{
		timer += Time.deltaTime;
		switch(gunIsDead)
		{
			case true:
			break;
			
			case false:
			if(timer >= delay)
			{
				Shoot();
				timer = 0;
			}
			break;
		}
	}
	
	private void Shoot()
    {
		if(!canShoot) return;
		FireGun();
		StartCoroutine(CanShoot());
    }
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(delay);
		canShoot = true;
	}
	
	public void FireGun()
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
			Vector2 bulDir =(bulMoveVector - transform.position).normalized;
			GameObject g = eBulletPool.GetObject();
			g.transform.position = new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z);
			g.transform.rotation = transform.rotation;		
			render = g.transform.GetComponent<SpriteRenderer>();
			render.sprite = bulletImage;			
			g.SetActive(true);
			eBullet = g.GetComponent<EnemyBullet>();
			eBullet.speed = force;
			eBullet.lifeTime = distance;
			eBullet.SwitchColliders(colliderType);
			eBullet.SetMoveDirection(bulDir);
			angle += angleStep;
			xPos += xPosStep;
		}
	}
}
