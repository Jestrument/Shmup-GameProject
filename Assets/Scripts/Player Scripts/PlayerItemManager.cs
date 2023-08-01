using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
	//Weapon Counts 
	public int itemMax = 3;
	public int weaponB;
	public int weaponG;
	public int weaponL;
	public int weaponM;
	public int weaponS;
	
	//Gun barrel
	[SerializeField] GunPoint barrel;
	
	//Weapon Sprites and Weapon SpriteRenderer
	[SerializeField] public SpriteRenderer gunImage;
	[SerializeField] public Sprite gunB;
	[SerializeField] public Sprite gunG;
	[SerializeField] public Sprite gunL;
	[SerializeField] public Sprite gunMLvl1;
	[SerializeField] public Sprite gunMLvl2;
	[SerializeField] public Sprite gunMLvl3;
	[SerializeField] public Sprite gunS;
	
	
	//Player Movement
	[SerializeField] DropPooler dropPooler;
	
	//Hitpoint Manager
	[SerializeField] PlayerHealthSystem pHS;
	
	//Ui Manager
	[SerializeField] PlayerUiManager UiManager;
	
	//Timer Manager
	[SerializeField] Timer timer;
	public float fuelAmount;
	
	//Player Collider
	[SerializeField] public Collider2D playerCollider;
		
	private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
		{
			case "B":
			weaponB++;
			switch(weaponB)
			{
				case >3:
				weaponB = itemMax;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 3:
				barrel.ChangeBulletType("B3");
				UiManager.UpdateWeaponLevel(3);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 2:
				barrel.ChangeBulletType("B2");
				UiManager.UpdateWeaponLevel(2);
				dropPooler.ReturnObject(other.gameObject);;
				break;
				
				case 1:
				SwitchWeapons(1);
				barrel.ChangeBulletType("B1");
				UiManager.UpdateWeaponLevel(1);
				UiManager.UpdateWeaponImage(1);
				dropPooler.ReturnObject(other.gameObject);
				weaponG = 0;
				weaponL = 0;
				weaponM = 0;
				weaponS = 0;
				break;
				
				case 0:
				break;
			}
			
			break;
			
			case "G":
			weaponG++;
			switch(weaponG)
			{
				case >3:
				weaponG = itemMax;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 3:
				barrel.ChangeBulletType("G3");
				UiManager.UpdateWeaponLevel(3);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 2:
				barrel.ChangeBulletType("G2");
				UiManager.UpdateWeaponLevel(2);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 1:
				SwitchWeapons(2);
				barrel.ChangeBulletType("G1");
				UiManager.UpdateWeaponLevel(1);
				UiManager.UpdateWeaponImage(2);
				weaponB= 0;
				weaponL = 0;
				weaponM = 0;
				weaponS = 0;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 0:
				break;
			}
			break;
			
			case "L":
			weaponL++;
			switch(weaponL)
			{
				case >3:
				weaponL = itemMax;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 3:
				barrel.ChangeBulletType("L3");
				UiManager.UpdateWeaponLevel(3);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 2:
				barrel.ChangeBulletType("L2");
				UiManager.UpdateWeaponLevel(2);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 1:
				SwitchWeapons(3);
				barrel.ChangeBulletType("L1");
				UiManager.UpdateWeaponLevel(1);
				UiManager.UpdateWeaponImage(3);
				weaponB = 0;
				weaponG = 0;
				weaponM = 0;
				weaponS = 0;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 0:
				break;
			}
			break;
			
			case "M":
			weaponM++;
			switch(weaponM)
			{
				case >3:
				weaponM = itemMax;
				dropPooler.ReturnObject(other.gameObject);;
				break;
				
				case 3:
				GunMLevel(3);
				barrel.ChangeBulletType("M3");
				UiManager.UpdateWeaponLevel(3);
				dropPooler.ReturnObject(other.gameObject);;
				break;
				
				case 2:
				GunMLevel(2);
				barrel.ChangeBulletType("M2");
				UiManager.UpdateWeaponLevel(2);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 1:
				GunMLevel(1);
				barrel.ChangeBulletType("M1");
				UiManager.UpdateWeaponLevel(1);
				UiManager.UpdateWeaponImage(4);
				weaponB = 0;
				weaponG = 0;
				weaponL = 0;
				weaponS = 0;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 0:
				break;
			}
			break;
			
			case "S":
			weaponS++;
			switch(weaponS)
			{
				case >3:
				weaponS = itemMax;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 3:
				barrel.ChangeBulletType("S3");
				UiManager.UpdateWeaponLevel(3);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 2:
				barrel.ChangeBulletType("S2");
				UiManager.UpdateWeaponLevel(2);
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 1:
				SwitchWeapons(4);
				barrel.ChangeBulletType("S1");
				UiManager.UpdateWeaponLevel(1);
				UiManager.UpdateWeaponImage(5);
				weaponB = 0;
				weaponG = 0;
				weaponL = 0;
				weaponM = 0;
				dropPooler.ReturnObject(other.gameObject);
				break;
				
				case 0:
				break;
			}
			break;
			
			case "Gas":
			timer.AddGas(fuelAmount);
			dropPooler.ReturnObject(other.gameObject);
			break;
			
			case "Health":
			pHS.HealDamage(1);
			dropPooler.ReturnObject(other.gameObject);
			break;
			
			case "1Up":
			UiManager.IncreaseLiveCount(500);
			UiManager.UpdateLivesText();
			dropPooler.ReturnObject(other.gameObject);
			break;
			
			case "Score":
			UiManager.IncreaseScoreCount(500);
			UiManager.UpdateScoreText();
			dropPooler.ReturnObject(other.gameObject);
			break;
			
			case "Shield":
			pHS.shieldHits++;
			pHS.SetShieldColor(pHS.shieldHits);
			Destroy(other.gameObject);
			break;
			
			case "TorpedoBundle":
			UiManager.IncreaseTorpedoCount(3);
			UiManager.UpdateTorpedoText();
			dropPooler.ReturnObject(other.gameObject);
			break;
			
			case "Torpedo":
			UiManager.IncreaseTorpedoCount(1);
			UiManager.UpdateTorpedoText();
			dropPooler.ReturnObject(other.gameObject);
			break;
		}
    }
	
	private void SwitchWeapons(int weaponNumber)
	{
		switch(weaponNumber)
		{
			case 1:
			gunImage.sprite = gunB;
			break;
			
			case 2:
			gunImage.sprite = gunG;
			break;
			
			case 3:
			gunImage.sprite = gunL;
			break;
			
			case 4:
			gunImage.sprite = gunS;
			break;
		}
	}
	
	private void GunMLevel(int mLevel)
	{
		switch(mLevel)
		{
			case 1:
			gunImage.sprite = gunMLvl1;
			break;
			
			case 2:
			gunImage.sprite = gunMLvl2;
			break;
			
			case 3:
			gunImage.sprite = gunMLvl3;
			break;
		}
	}
}
