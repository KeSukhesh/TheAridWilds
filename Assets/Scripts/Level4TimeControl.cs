using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4TimeControl : MonoBehaviour
{
    // The only gameobject affected:
    public EnemyPatrolAI enemyPatrolAI1;

    // Update is called once per frame
    void Update()
    {
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.H)) // IF user presses H
        {
            // Change values to create slow down effect:
            enemyPatrolAI1.enemySpeed = 1.25f;

            Debug.Log("Slow down"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.J)) // IF user presses J
        {
            // Change values to create Paused time effect:
            enemyPatrolAI1.enemySpeed = 0f;

            Debug.Log("Pause"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.K)) // IF user presses K
        {
            // Change values to let objects resume at normal pace
            enemyPatrolAI1.enemySpeed = 10f;

            Debug.Log("Play"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.L)) // IF user presses L
        {
            // Change values to let objects fast forward, creating time control effect:
            enemyPatrolAI1.enemySpeed = 20f;

            Debug.Log("Speed Up"); // for testing
        }
    }
}
