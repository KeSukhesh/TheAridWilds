using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour
{
	private float dirY; // Y value
	public float topYValue = 4f; // highest y value platform goes to
	public float bottomYValue = 4f; // lowest y value platform goesto
	public float moveSpeed = 3f; // how fast platform moves
	public bool moveUp = true; // Is platform moving up bool

	// Update is called once per frame
	void Update()
	{
		if (transform.position.y > topYValue) // If PLatform is greater than top y value
			moveUp = false; // don't move up
		if (transform.position.y < bottomYValue) // if platform is lower than bottom y value
			moveUp = true; // move platform up

		if (moveUp) // if platform is moving up
			transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime); // Move platforum up in y direction relative to move speed and time
		else // if platform is moving down
			transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime); // Move platform down in y direction relative to move speed and time
	}
}
