using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private DeathPooler deathPooler;
	
	private Vector2 moveDirection;
	[SerializeField] float lifeTime = 2f;
	
	private void Start()
	{
		deathPooler = transform.parent.GetComponent<DeathPooler>();
	}
	
	private void OnEnable()
    {
        StartCoroutine(DestroyDeathAfterTime());
    }
	
	IEnumerator DestroyDeathAfterTime()
	{
		yield return new WaitForSeconds(lifeTime);
		deathPooler.ReturnObject(gameObject);
	}
}
