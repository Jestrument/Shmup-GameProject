using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
	public string lootName;
	public Sprite border;
	public Sprite itemImage;
	public string itemTag;
	public int dropChance;
}
