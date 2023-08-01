using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTarget : MonoBehaviour
{
	private GameObject player;
	
	private Rigidbody2D rb;

	
    void Start()
    {
        player = GameObject.FindWithTag("Player");
		rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rb.rotation = angle + 90f;
		direction.Normalize();
    }
}
