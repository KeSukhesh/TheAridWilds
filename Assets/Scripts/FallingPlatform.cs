using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	Rigidbody2D rb; // PLatforms physical body
	public float fallSpeed = 0.5f; // How fast platform falls
	public float destroySpeed = 2f; // How long till platform object is destroyed

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>(); //set reference
	}

	void OnCollisionEnter2D(Collision2D col) // collision detection
	{
		if (col.gameObject.name.Equals("Player")) // if collision with player
		{
			Invoke("DropPlatform", fallSpeed); // Initiate drop platform function, using fall speed
			Destroy(gameObject, destroySpeed); // Destroy the gameobject using destroy speed
		}
	}

	void DropPlatform() //platform should drop
	{
		rb.isKinematic = false; // don't listen to physics
	}
}
