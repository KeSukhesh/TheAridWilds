using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	public Slider slider; //reference to slider
	public Gradient gradient; //reference to colour
	public Image fill; //reference to image to be filled with

	public void SetMaxHealth(int health) //function to set max health, health is passed into here
	{
		slider.maxValue = health; // Slider max value should be health
		slider.value = health; //slider value is also health

		fill.color = gradient.Evaluate(1f); // Determine what shade colour of healthbar should be
	}

	public void SetHealth(int health) // function to set health, health is passed into here
	{
		slider.value = health; // slider value is health

		fill.color = gradient.Evaluate(slider.normalizedValue); // colour is filled relative to how much hp player has left
	}

}
