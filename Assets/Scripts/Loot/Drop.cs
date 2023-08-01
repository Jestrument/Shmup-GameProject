using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
	private DropPooler dropPooler;
	
	[SerializeField] SpriteRenderer border;
	[SerializeField] SpriteRenderer item;
	
	private Color borderColor;
	private Color itemColor; 
	
	private Vector2 moveDirection;
	[SerializeField] public float speed = 1;
	
	private void Start()
	{
		dropPooler = transform.parent.GetComponent<DropPooler>();
		borderColor = border.color;
		itemColor = item.color;
	}
	
	private void OnEnable()
    {
		gameObject.SetActive(true);
        StartCoroutine(DestroyDropAfterTime());
    }
	
	IEnumerator DestroyDropAfterTime()
	{
		yield return new WaitForSeconds(1.5f);
		borderColor.a = 0;
		itemColor.a = 0;
		yield return new WaitForSeconds(0.6f);
		borderColor.a = 1;
		itemColor.a = 1;
		yield return new WaitForSeconds(0.75f);
		borderColor.a = 0;
		itemColor.a = 0;
		yield return new WaitForSeconds(0.6f);
		borderColor.a = 1;
		itemColor.a = 1;
		yield return new WaitForSeconds(0.65f);
		borderColor.a = 0;
		itemColor.a = 0;
		yield return new WaitForSeconds(0.6f);
		borderColor.a = 1;
		itemColor.a = 1;
		yield return new WaitForSeconds(0.6f);
		borderColor.a = 0;
		itemColor.a = 0;
		gameObject.SetActive(false);
		dropPooler.ReturnObject(gameObject);
	}
	
	void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
	
	public void SetMoveDirection(Vector2 dir)
	{
		moveDirection = dir;
	}
}
