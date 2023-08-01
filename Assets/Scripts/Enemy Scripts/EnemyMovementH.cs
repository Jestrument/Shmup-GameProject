using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementH : MonoBehaviour
{
	private GameObject player;
	
	public float speed= 3;
	public bool reverseSpeed;
	
	private Rigidbody2D rb;
	private Vector2 movement;
	
	void Start()
	{
		player = GameObject.FindWithTag("Player");
		rb = this.GetComponent<Rigidbody2D>();
	}
	
    void Update()
    {
		Vector3 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rb.rotation = angle + -90f;
		direction.Normalize();
		movement = direction;
    }
	
	void FixedUpdate()
	{
		MoveCharacter(movement);
	}
	
	void MoveCharacter(Vector2 moveDirection)
	{
		switch(reverseSpeed)
		{
			case true:
			rb.MovePosition((Vector2)transform.position + (moveDirection * -speed * Time.fixedDeltaTime));
			break;
			
			case false:
			rb.MovePosition((Vector2)transform.position + (moveDirection * speed * Time.fixedDeltaTime));
			break;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.tag)
		{
			case "Player":
			StartCoroutine(DelayHoming());
			break;
		}
	}
	
	public IEnumerator DelayHoming()
	{
		reverseSpeed = true;
		yield return new WaitForSeconds(2f);
		reverseSpeed = false;
	}
}
