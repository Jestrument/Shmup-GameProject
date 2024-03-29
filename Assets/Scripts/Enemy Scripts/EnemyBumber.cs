using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBumber : MonoBehaviour
{
	public int maxHealth = 5;
	public int health;
	
	[SerializeField] SpriteRenderer render;
	[SerializeField] Sprite original;
	[SerializeField] Sprite flash;
	
	EnemyMovementH moveH;
	
	void OnEnable()
	{
		health = maxHealth;
		moveH = transform.parent.GetComponent<EnemyMovementH>();
		Reset();
	}
	
	public void TakeDamage(int damage)
	{	
		health -= damage;
		StartCoroutine(HitFlash());
		if(health <= 0)
		{
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
	}
}
