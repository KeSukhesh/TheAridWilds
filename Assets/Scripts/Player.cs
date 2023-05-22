using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public PlayerController controller; // Reference to player controller

	public float runSpeed = 40f; // How fast player can run

	float horizontalMove = 0f; // Horizontal move force
	bool jump = false; // Is player jumping
	bool crouch = false; //Is player crouching

	
	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Set horizontal force value

		if (Input.GetButtonDown("Jump")) // Did user press Jump key
		{
			jump = true; // Player jumps
		}

		if (Input.GetButtonDown("Crouch")) // Did User press Crouch Key
		{
			crouch = true; // Player Crouches
		}
		else if (Input.GetButtonUp("Crouch")) // Did Player let go of crouch key
		{
			crouch = false; // Stop crouching
		}

		if (Input.GetMouseButtonDown(0)) // If user clicks
			AudioManager.instance.PlaySFX("click"); // Click sfx
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump); // Pass the horizontal force to player controller script
		jump = false; // Jump is false by default unless player presses jump key
		
	}
}
