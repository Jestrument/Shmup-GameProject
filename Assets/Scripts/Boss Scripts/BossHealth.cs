using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
	
	[SerializeField] SpriteRenderer render;
	[SerializeField] Sprite original;
	[SerializeField] Sprite flash;
	public float offsetX;
	public float offsetY;
	
	DeathPooler deathPooler;
	
	private void Start()
	{
		deathPooler = GameObject.FindWithTag("DeathPooler").GetComponent<DeathPooler>();
	}
	
	public void TakeDamage(int damage)
	{	
		health -= damage;
		StartCoroutine(HitFlash());
		if(health <= 0)
		{
			GameObject g = deathPooler.GetObject();
			g.transform.position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);
			g.transform.rotation = Quaternion.identity;
			g.transform.localScale = transform.localScale;
			g.SetActive(true);
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
}
