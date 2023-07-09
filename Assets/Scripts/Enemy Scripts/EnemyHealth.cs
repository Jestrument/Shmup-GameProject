using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 10;
	[SerializeField] GameObject[] guns;
	
	[SerializeField] SpriteRenderer render;
	[SerializeField] Sprite original;
	[SerializeField] Sprite flash;
	
	EnemyPooler enemyPooler;
	DeathPooler deathPooler;
	
	private void Start()
	{
		enemyPooler = transform.parent.GetComponent<EnemyPooler>();
		deathPooler = GameObject.FindWithTag("DeathPooler").GetComponent<DeathPooler>();
	}
	
   public void TakeDamage(int damage)
	{	
		health -= damage;
		StartCoroutine(HitFlash());
		if(health <= 0)
		{
			GameObject g = deathPooler.GetObject();
			g.transform.position = transform.position;
			g.transform.rotation = Quaternion.identity;
			g.SetActive(true);
			this.gameObject.SetActive(false);
			foreach(GameObject gun in guns)
			{
				gun.SetActive(true);
			}
			enemyPooler.ReturnObject(gameObject);
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
}
