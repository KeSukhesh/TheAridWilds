using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacePlayer : MonoBehaviour
{
    //Sript says "enemy" But this is just for idle scorpions
    public Transform player; // st reference to player game object

    // Update is called once per frame
    void Update()
    {
        FacePlayer(); // Constantly face player
    }
    void FacePlayer()
    {
        //Flip the enemy transform to look into the player's direction
        if (player.transform.position.x > transform.position.x) // If player is on right of scorpion
            transform.localScale = new Vector3(-4, 4, 4); // Scorpion face right
        else // else if player is on left of scorpion
            transform.localScale = new Vector3(4, 4, 4); // Scorpion stays facing left
    }
}
