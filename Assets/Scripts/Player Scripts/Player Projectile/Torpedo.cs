using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
	private TorpedoPooler torpedoPooler;
	
	private Vector2 moveDirection;
	[SerializeField] public float speed;
	[SerializeField] public float lifeTime;
	
    void Start()
    {
        torpedoPooler = transform.parent.GetComponent<TorpedoPooler>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyTorpedoAfterTime());
    }
	
	IEnumerator DestroyTorpedoAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		torpedoPooler.ReturnObject(gameObject);
	}
	
	 void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
	
	public void SetMoveDirection(Vector2 dir)
	{
		moveDirection = dir;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		switch(other.tag)
		{
			case "Gamebounds":
			torpedoPooler.ReturnObject(gameObject);
			break;
		}
	}
}