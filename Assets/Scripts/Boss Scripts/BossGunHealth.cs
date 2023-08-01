using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGunHealth : MonoBehaviour
{
	private BossGunPoint gun;
	
	public int maxHealth;
    public int health;
	
	[SerializeField] SpriteRenderer render;
	[SerializeField] Sprite original;
	[SerializeField] Sprite flash;
	
	DeathPooler deathPooler;
	
	private void Start()
	{
		gun = GetComponent<BossGunPoint>();
		deathPooler = GameObject.FindWithTag("DeathPooler").GetComponent<DeathPooler>();
	}
	
	private void OnEnable()
	{
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
	
	void Reset()
	{
		health = maxHealth;
		render.sprite = original;
		render.color = Color.white;
	}
}
