using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
	
	//Health System
	public int maxHealth = 4;
	public int currentHealth;
	public int lives;
	[SerializeField] SpriteRenderer boat;
	[SerializeField] Sprite outline;
	[SerializeField] Sprite hit;
	[SerializeField] GameObject smoke;
	
	//HealthBar UI Elements
	[SerializeField] Slider slider;
	[SerializeField] Image fill;
	public Gradient healthBarColor;
	
	//Shield
	public bool isShieldOn = false;
	public int shieldHits;
	public int shiledHitsMax = 10;
	[SerializeField] public SpriteRenderer shieldImage;
	[SerializeField] Color maxColor;
	[SerializeField] Color secondColor;
	[SerializeField] Color thirdColor;
	[SerializeField] Color fourthColor;
	[SerializeField] Color fifthColor;
	[SerializeField] Color sixthColor;
	[SerializeField] Color seventhColor;
	[SerializeField] Color eightColor;
	[SerializeField] Color ninthColor;
	[SerializeField] Color lastColor;
	
	
	//For Death System
	[SerializeField] Collider2D playerCollider;
	[SerializeField] Animator playerAnimator; 
	[SerializeField] DeathPooler deathPooler;
	private Animator animator; 
	
    private void Awake()
    {
		currentHealth = maxHealth;
		SetMaxHealth(currentHealth);
    }
	
	public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
		slider.value = health;
		
		fill.color = healthBarColor.Evaluate(1f);
    }
	
    public void SetHealth(int health)
    {
        slider.value = health;
		fill.color = healthBarColor.Evaluate(slider.normalizedValue);
    }
	
	public void TakeDamage(int damage)
	{	
		switch(isShieldOn)
		{
			case true:
			shieldHits-=damage;
			SetShieldColor(shieldHits);
			break;
			
			case false:
			currentHealth-= damage;
			StartCoroutine(HitFlash());
			if(currentHealth == 1)
			{
				smoke.SetActive(true);
			}
			if(currentHealth == 0)
			{
				StartCoroutine(Die());
			}
			SetHealth(currentHealth);					
			break;
		}
		
	}
	
	public void HealDamage(int healAmount)
	{
		currentHealth += healAmount;
		
		if(currentHealth > 1)
		{
			smoke.SetActive(false);
		}
		
		if(currentHealth > maxHealth)
		{
			currentHealth= maxHealth;
		}
		SetHealth(currentHealth);
	}
	
    public void SetShieldColor(int shieldColor)
    {		
		switch(shieldColor)
		{
			case >10:
			shieldColor = shiledHitsMax;
			break;
			
			case 10:
			shieldImage.color = maxColor;
			break;
			
			case 9:
			shieldImage.color = secondColor;
			break;
			
			case 8:
			shieldImage.color = thirdColor;
			break;
			
			case 7:
			shieldImage.color = fourthColor;
			break;
			
			case 6:
			shieldImage.color = fifthColor;
			break;
			
			case 5:
			shieldImage.color = sixthColor;
			break;
			
			case 4:
			shieldImage.color = seventhColor;
			break;
			
			case 3:
			shieldImage.color = eightColor;
			break;
			
			case 2:
			shieldImage.color = ninthColor;
			break;
			
			case 1:
			shieldImage.color = lastColor;
			isShieldOn = true;
			shieldImage.enabled = true;
			break;
			
			case 0:
			isShieldOn = false;
			shieldImage.enabled = false;
			break;
			
			case <0:
			shieldColor = 0;
			break;
		}
    }
	
	IEnumerator HitFlash()
	{
		boat.sprite = hit;
		boat.color = new Color(0.8f, 0.8f, 0.8f);
		yield return new WaitForSeconds(0.1f);
		boat.sprite = outline;
		boat.color = Color.white;
	}
	
	IEnumerator Die()
	{
		GameObject g = deathPooler.GetObject();
		g.transform.position = transform.position;
		g.transform.rotation = Quaternion.identity;
		g.SetActive(true);
		animator = g.GetComponent<Animator>();
		animator.PlayInFixedTime("Explode");
		yield return new WaitForSeconds(.1f);
		HealDamage(4);
		playerCollider.enabled = false;
		playerAnimator.enabled = true;
		playerAnimator.PlayInFixedTime("Respawn");
		yield return new WaitForSeconds(1f);
		playerCollider.enabled = true;
		playerAnimator.enabled = false;
		
		if(lives == 0)
		{
			GameOver();
		}
	}
	
	void GameOver()
	{
		
	}
}