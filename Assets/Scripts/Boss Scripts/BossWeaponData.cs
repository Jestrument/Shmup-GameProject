using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossWeapon" )]
public class BossWeaponData : ScriptableObject
{
    public Sprite bulletImage;
	
	public float force;
	public float distance;
	public int colliderType;
}
