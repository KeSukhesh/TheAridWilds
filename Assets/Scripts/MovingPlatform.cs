using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	private float dirX; // X value
	public float rightXValue = 4f; // Furthest right value platform can go to
	public float leftXValue = 4f; // Furthest left value platform can go to
	public float moveSpeed = 3f; // how fast platform moves
	public bool moveRight = true; // Is platform moving right

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x > rightXValue) // if platform is to the right of furthest right value it should be
			moveRight = false; // don't move right anymore
		if (transform.position.x < leftXValue) // if platform is to the left of furthest left value it should be
			moveRight = true; // move right

		if (moveRight) // if platform should move right
			transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y); // Platform x direction increases relative to move speed and time
		else // platform should move left
			transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // PLatform x direction decreases relative to move speed and time.
	}
}
