using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
	//Player Inputs
	private Controls input;
	
	//GunPoint
	[SerializeField] private GunPoint gunPoint;
	
	//Delay and Can we shoot
	private bool canShoot = true;
	public float delay;
	
    private void Awake()
    {
        input = new Controls();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Shoot.performed += OnShootPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Shoot.performed -= OnShootPerformed;
    }
	
	private void OnShootPerformed(InputAction.CallbackContext context)
    {
		if(!canShoot) return;
		gunPoint.Shoot();
		StartCoroutine(CanShoot());
    }
	
	
	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds(delay);
		canShoot = true;
	}
}
