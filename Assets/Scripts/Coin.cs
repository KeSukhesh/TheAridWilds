using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Value to add to counter

    private void OnTriggerEnter2D(Collider2D other) // Collision detection
    {
        if (other.gameObject.CompareTag("CoinCollector")) // If collides with player's coin colector colliderr
        {
            ScoreManager.instance.ChangeScore(coinValue); // Add 1 to text
            Destroy(gameObject); // Destroy the coin // Destroy this coin
            
        }
    }
}
