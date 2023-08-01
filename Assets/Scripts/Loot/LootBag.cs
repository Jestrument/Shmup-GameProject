using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
	public List<Loot> lootList = new List<Loot>();
	private DropPooler dropPooler;
	
	void Start()
	{
		dropPooler = GameObject.FindWithTag("DropPooler").GetComponent<DropPooler>();
	}
	
	Loot GetDroppedItem()
	{
		int randomNumber = Random.Range(1,101);
		List<Loot> possibleItems = new List<Loot>();
		foreach(Loot item in lootList)
		{
			if(randomNumber <= item.dropChance)
			{
				possibleItems.Add(item);
			}
		}
		
		if(possibleItems.Count > 0)
		{
			Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
			return droppedItem;
		}
		
		return null;
	}
	
	public void GetLoots(Vector3 spawnPoint)
	{
		Loot droppedItem = GetDroppedItem();
		
		if(droppedItem != null)
		{
			GameObject g = dropPooler.GetObject();
			g.transform.position = spawnPoint;
			g.transform.rotation = Quaternion.identity;
			g.GetComponent<SpriteRenderer>().sprite = droppedItem.border;
			g.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = droppedItem.itemImage;
			g.tag = droppedItem.itemTag;
			g.SetActive(true);
			Vector2 itemDir = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
			g.GetComponent<Drop>().SetMoveDirection(itemDir);
		}
	}
}
