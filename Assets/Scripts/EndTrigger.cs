using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Assign by dragging the GameObject with ScriptA into the inspector before running the game.
    public GameManager gameManager; // set reference

    private void OnTriggerEnter2D(Collider2D collision) // collision detection
    {
        if (collision.tag == "Player") // If collides with player
        {
            gameManager.CompleteLevel(); // Initiate next level load function
        }
    }
}
