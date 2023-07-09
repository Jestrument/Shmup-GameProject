using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUiManager : MonoBehaviour
{
	//Weapon Images
	[SerializeField] public Image currentWeaponImage;
	[SerializeField] public Sprite weaponBUi;
	[SerializeField] public Sprite weaponGUi;
	[SerializeField] public Sprite weaponLUi;
	[SerializeField] public Sprite weaponMUi;
	[SerializeField] public Sprite weaponSUi;
	
	//UI Text and UI itemcount
	[SerializeField] TextMeshProUGUI weaponLevelText;
	[SerializeField] TextMeshProUGUI livesText;
	public int lives;
	[SerializeField] TextMeshProUGUI torpedoText;
	public int torpedoAmount;
	[SerializeField] TextMeshProUGUI scoreText;
	public int scoreAmount;
	
	
	//Player Health System
	[SerializeField] PlayerHealthSystem pHS;
	
	public void UpdateWeaponImage(int changedImage)
	{
		switch(changedImage)
		{
			case 1:
			currentWeaponImage.sprite = weaponBUi;
			break;
			
			case 2:
			currentWeaponImage.sprite = weaponGUi;
			break;
			
			case 3:
			currentWeaponImage.sprite = weaponLUi;
			break;
			
			case 4:
			currentWeaponImage.sprite = weaponMUi;
			break;
			
			case 5:
			currentWeaponImage.sprite = weaponSUi;
			break;
		}
	}
	
	public void UpdateWeaponLevel(int level)
	{
		switch(level)
		{
			case 1:
			weaponLevelText.text = ("");
			break;
		
			case 2:
			weaponLevelText.text = ("Lvl 2");
			break;
		
			case 3:
			weaponLevelText.text = ("Lvl Max");
			break;
		}
		
	}
	
	public void IncreaseLiveCount(int amount)
	{
		lives += amount;
	}
	
	public void DecreaseLiveCount(int amount)
	{
		lives -= amount;
	}
	
	public void UpdateLivesText()
	{
		switch(lives)
		{
			case 0:
			livesText.text = "";
			break;
			
			default:
			livesText.text = "X" + lives;
			break;
		}
	}
	
	public void IncreaseTorpedoCount(int amount)
	{
		torpedoAmount += amount;
	}
	
	public void DecreaseTorpedoLiveCount(int amount)
	{
		torpedoAmount -= amount;
	}
	
	public void UpdateTorpedoText()
	{
		switch(torpedoAmount)
		{
			case 0:
			torpedoText.text = "";
			break;
			
			default:
			torpedoText.text = "X" + torpedoAmount;
			break;
		}
	}
	
	public void IncreaseScoreCount(int amount)
	{
		scoreAmount += amount;
	}
	
	public void DecreaseScoreCount(int amount)
	{
		scoreAmount -= amount;
	}
	
	public void UpdateScoreText()
	{
		scoreText.text = "Score: " + scoreAmount; 
	}
	
	
	
	
	
	
	
	
}
