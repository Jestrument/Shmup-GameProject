using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomizeColor : MonoBehaviour
{
	
	[SerializeField] private Slider hueSlider;
	[SerializeField] private Slider satSlider;
	[SerializeField] private Slider valSlider;
	
	[SerializeField] private Image colorImage;
	[SerializeField] private Image boatUI;
	[SerializeField] private Image boatPlayerUI;
	
	[SerializeField] private SpriteRenderer baseHead;
	[SerializeField] private SpriteRenderer baseBody;
	[SerializeField] private SpriteRenderer baseArmL;
	[SerializeField] private SpriteRenderer baseArmR;
	[SerializeField] private SpriteRenderer baseLegL;
	[SerializeField] private SpriteRenderer baseLegR;
	
	[SerializeField] private SpriteRenderer boat;
	[SerializeField] private SpriteRenderer boatPlayer;
	
	float minValue = 0f;
	float maxValue = 1f;
	
	float currentHue;
	float currentSat;
	float currentVal;
	
	Color playerColor;
	
    void Start()
    {
        hueSlider.maxValue = maxValue;
		hueSlider.minValue = minValue;
		hueSlider.value = maxValue;
		
		satSlider.maxValue = maxValue;
		satSlider.minValue = minValue;
		satSlider.value = minValue;
		
		valSlider.maxValue = maxValue;
		valSlider.minValue = minValue;
		valSlider.value = maxValue;
    }


    void Update()
    {
		currentHue = hueSlider.value;
		currentSat = satSlider.value;
		currentVal = valSlider.value;
		
		playerColor = Color.HSVToRGB(currentHue, currentSat, currentVal);
		
		colorImage.color = playerColor;
		boatUI.color = playerColor;
		boatPlayerUI.color = playerColor;
		
		baseHead.color = playerColor;
		baseBody.color = playerColor;
		baseArmL.color = playerColor;
		baseArmR.color = playerColor;
		baseLegL.color = playerColor;
		baseLegR.color = playerColor;
		
		boat.color = playerColor;
		boatPlayer.color = playerColor;
    }
}
