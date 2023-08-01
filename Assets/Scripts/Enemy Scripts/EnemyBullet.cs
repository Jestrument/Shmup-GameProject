using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public EnemyBulletPooler eBullets;
	
	private Vector2 moveDirection;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
	public Collider2D[] colliderType;
	public Collider2D currentCollider;
	
	private void Start()
	{
		eBullets = transform.parent.GetComponent<EnemyBulletPooler>();
	}
	
    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }
	
	IEnumerator DestroyBulletAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		eBullets.ReturnObject(gameObject);
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
			case "Player":
			PlayerHealthSystem pHS = other.gameObject.GetComponent<PlayerHealthSystem>();
			pHS.TakeDamage(1);
			eBullets.ReturnObject(gameObject);
			break;
			
			case "Gamebounds":
			eBullets.ReturnObject(gameObject);
			break;
		}
	}
}
