using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField] Transform needle;
	
	private float zeroSpeedAngle = -90.0f;
	private float maxSpeedAngle = 90.0f;
	
	[SerializeField] private float speed;
	[SerializeField] private float speedMin;
	[SerializeField] private float speedMax;
	[SerializeField] private float needleSpeed;
		
    void Update()
    {
		speed += needleSpeed * Time.deltaTime;
		if(speed > speedMax)
		{
			speed = speedMax;
		}
		
		if(speed < speedMin)
		{
			speed = speedMin;
		}
		needle.eulerAngles = new Vector3(0, 0, GetRotation());
    }
	
	
	private float GetRotation()
	{
		float totalAngleSize = zeroSpeedAngle - maxSpeedAngle;
		
		float speedNormalized = speed/ speedMax;
		
		return zeroSpeedAngle - speedNormalized * totalAngleSize; 
	}
	
	public void AddGas(float fuel)
	{
		speed -= fuel;
	}
}
