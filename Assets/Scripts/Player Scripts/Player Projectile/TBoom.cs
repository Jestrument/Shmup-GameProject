using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBoom : MonoBehaviour
{
	private TBoomPooler tBoomPooler;
	
	private Vector2 moveDirection;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
	[SerializeField] EnemyHealth enemy;
	[SerializeField] EnemyGunHealth eGun;
	[SerializeField] EnemyBullet eBullet;
	[SerializeField] EnemyBumber eBumber;
	
	[SerializeField] BossGunHealth bGun;
	[SerializeField] BossHealth boss;
	
    void Start()
    {
		tBoomPooler = transform.parent.GetComponent<TBoomPooler>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyTBoomAfterTime());
    }
	
	IEnumerator DestroyTBoomAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		tBoomPooler.ReturnObject(gameObject);
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
			case "Enemy":
			enemy = other.gameObject.GetComponent<EnemyHealth>();
			enemy.TakeDamage(10);
			break;
			
			case "Bumber":
			eBumber = other.gameObject.GetComponent<EnemyBumber>();
			eBumber.TakeDamage(10);
			break;
			
			case "Gun":
			eGun = other.gameObject.GetComponent<EnemyGunHealth>();
			eGun.TakeDamage(10);
			break;
			
			case "EBullet":
			eBullet = other.gameObject.GetComponent<EnemyBullet>();
			other.gameObject.SetActive(false);
			eBullet.eBullets.ReturnObject(other.gameObject);
			break;

			case "BossGun":
			bGun = other.gameObject.GetComponent<BossGunHealth>();
			bGun.TakeDamage(5);
			break;

			case "Boss":
			boss = other.gameObject.GetComponent<BossHealth>();
			boss.TakeDamage(5);
			break;
		}
	}
}
