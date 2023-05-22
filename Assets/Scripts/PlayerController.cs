using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float jumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool airControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask whatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform groundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform ceilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D crouchDisableCollider;                // A collider that will be disabled when crouching
	public Animator animator;

	const float groundCheckRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool isGrounded;            // Whether or not the player is grounded.
	const float ceilingCheckRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D rb;				//Player's Rigidbody Component
	private bool playerFacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 rVelocity = Vector3.zero; // Vector for Player's movement adjustments
	public float bounceForce; // Ammount that the Player bounces by.

	public int maxHealth = 100; //Player's Max Health
	public int currentHealth; //PLayer's Current health at all times
	public int damageTaken = 15; //Damage that Player takes
	public int spikeDamage = 100; //Damage a spike does
	public bool ctrlActive;
	//private bool isDead = false; // Player is dead bool
	private Collider2D playerCol; //Player's main collider
	public GameObject[] childObjs; // Array of child items of Player
	public float deathShockForce; // Bounce force but for death not damage

	public Healthbar healthBar; // Reference to Healthbar in HUD

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>(); // Set Reference
		animator = GetComponent<Animator>(); //Set Reference
	}

	void Start()
    {
		currentHealth = maxHealth; // Player starts with max health
		healthBar.SetMaxHealth(maxHealth); // Pass health value through to healthbar object

		playerCol = GetComponent<Collider2D>(); // Set Reference

		ctrlActive = true; // User can Control the Player game object

	}

	private void FixedUpdate()
	{
        #region GroundCheck
		isGrounded = false; // False by default so player can't spam jump and fly

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatIsGround); //Array of colliders to check plkayer's collision
		for (int i = 0; i < colliders.Length; i++) // Check both the groundcheck position and radius
		{
			if (colliders[i].gameObject != gameObject) // The game object is not equal to game object -> Its become a child of the "WhatisGround" layer
			{
				isGrounded = true; // Player is touching ground
			}

		}
		#endregion
	}

	void Update()
    {
		if (currentHealth <= 0) //If PLayer health is or below 0
        {
			FindObjectOfType<PlayerController>().Die(); // Initiate Die Function
		}
	}


    public void Move(float move, bool crouch, bool jump)
	{
		if (ctrlActive == true) // If Player is allowed to move
		{
			#region Crouching
			// If crouching, check to see if the character can stand up
			if (!crouch)
			{
				// If the character has a ceiling preventing them from standing up, keep them crouching
				if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround))
				{
					crouch = true; // Initiate Crouch
				}
			}
			#endregion

			#region Crouching + Jump & Aircontrol 
			//only control the player if grounded or airControl is turned on
			if (isGrounded || airControl) // If the player is on the ground or in the air
			{
				// If crouching
				if (crouch)
				{
					// Reduce the speed by the crouchSpeed multiplier
					move *= crouchSpeed;

					// Disable one of the colliders when crouching
					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = false;
				}
				else
				{
					// Enable the collider when not crouching
					if (crouchDisableCollider != null)
						crouchDisableCollider.enabled = true;
				}

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
				// And then smoothing it out and applying it to the character
				rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref rVelocity, movementSmoothing);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !playerFacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && playerFacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}
			// If the player should jump...
			if (isGrounded && jump)
			{
				animator.SetBool("isJumping", true);
				// Add a vertical force to the player.
				isGrounded = false; //PLayer is in air
				rb.AddForce(new Vector2(0f, jumpForce)); // Add vertical force to player game object
				AudioManager.instance.PlaySFX("jump"); // Jump sfx
			}
			#endregion

			#region Animation Parameters
			//Set the float xVelocity according the x value of the Rigidbody2D
			animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
			//Set the crouch animatom paramater bool to the player's crouch flag
			animator.SetBool("isCrouching", crouch);
			//Set the float yVelocity according the y value of the Rigidbody2D
			animator.SetFloat("yVelocity", rb.velocity.y);
			if (isGrounded) // if PLayer is on ground
			{
				animator.SetBool("isJumping", false);  //Don't play jump animation
			}
			#endregion
		}

	}

    #region Flip Player
    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		playerFacingRight = !playerFacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	#endregion

	#region HealthManager / TriggerManager
	void TakeDamage(int damage) // Function to take damage, damage val gets passed through from whatever did the damage
	{
		currentHealth -= damage; // Take away damage from health
		healthBar.SetHealth(currentHealth); //Update healthbar
	}

	private void OnTriggerEnter2D(Collider2D other) // Collision Detection
	{
		if (other.gameObject.tag == "Enemy") // Enemy Collision
		{
			TakeDamage(damageTaken); // damage player (passes damageTaken val to function)
			rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); // Add some bounce to player to escape collision
		}
		if (other.tag == "FallDetection") // If player falls off map
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart level
		}
		if (other.tag == "Spike") // If Player collides with scorpion (yes it says spike but its for the scorpions)
		{
			TakeDamage(spikeDamage); // Pass the scorpion damage through to the health.
			rb.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); // Add some bounce if the player doesn't die right away
		}
		if (other.tag == "Coins") // If collision with a coin
        {
			AudioManager.instance.PlaySFX("coin"); // PLay "collected coin" sound effect
		}
	}

	public void Die() // If Player has died
    {
		FindObjectOfType<LevelManager>().Restart(); // Restart level
		ctrlActive = false; //Don't let player move while dead
	}
	#endregion

}
