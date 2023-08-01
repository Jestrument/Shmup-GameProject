using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunHealth : MonoBehaviour
{
	private EnemyGunPoint gun;
	public int maxHealth = 2;
	public int health;
	
	[SerializeField] SpriteRenderer render;
	[SerializeField] Sprite original;
	[SerializeField] Sprite flash;
	
	private void OnEnable()
	{
		gun = GetComponent<EnemyGunPoint>();
		health = maxHealth;
	}

	public void TakeDamage(int damage)
	{	
		health -= damage;
		StartCoroutine(HitFlash());
		if(health <= 0)
		{
			GetComponent<LootBag>().GetLoots(transform.position);
			gun.gunIsDead = true;
			this.gameObject.SetActive(false);
			
			health = maxHealth;
		}
	}
	
	IEnumerator HitFlash()
	{
		render.sprite = flash;
		render.color = new Color(0.8f, 0.8f, 0.8f);
		yield return new WaitForSeconds(0.1f);
		render.sprite = original;
		render.color = Color.white;
	}
	
	public void Reset()
	{
		health = maxHealth;
		render.sprite = original;
		render.color = Color.white;
		this.gameObject.SetActive(true);
		gun.gunIsDead = false;
	}
	
	
}
