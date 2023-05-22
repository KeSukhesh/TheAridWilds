using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3TimeControl : MonoBehaviour
{
    // Time control effect for Level 3
    // Reference to game objects to be affected:
    [SerializeField] public DisappearingPlatform togglingPlatformManager1;
    public DisappearingPlatform togglingPlatformManager2;
    public DisappearingPlatform togglingPlatformManager3;

    public EnemyPatrolAI enemyPatrolAI1;
    public EnemyPatrolAI enemyPatrolAI2;

    // Update is called once per frame
    void Update()
    {
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.H))  // IF user presses H
        {
            // Change values to create slow down effect:
            enemyPatrolAI1.enemySpeed = 1f;
            enemyPatrolAI2.enemySpeed = 0.25f;

            togglingPlatformManager1.timeToTogglePlatform = 8f;
            togglingPlatformManager2.timeToTogglePlatform = 16f;
            togglingPlatformManager3.timeToTogglePlatform = 12f;

            Debug.Log("Slow down"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.J))  // IF user presses J
        {
            // Change values to create Paused time effect:
            enemyPatrolAI1.enemySpeed = 0f;
            enemyPatrolAI2.enemySpeed = 0f;

            togglingPlatformManager1.timeToTogglePlatform = 1000000f;
            togglingPlatformManager2.timeToTogglePlatform = 1000000f;
            togglingPlatformManager3.timeToTogglePlatform = 1000000f;

            Debug.Log("Pause"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.K))  // IF user presses K
        {
            // Change values to let objects resume at normal pace
            enemyPatrolAI1.enemySpeed = 8f;
            enemyPatrolAI2.enemySpeed = 2f;

            togglingPlatformManager1.timeToTogglePlatform = 2f;
            togglingPlatformManager2.timeToTogglePlatform = 4f;
            togglingPlatformManager3.timeToTogglePlatform = 3f;

            Debug.Log("Play"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.L))  // IF user presses L
        {
            // Change values to let objects fast forward, creating time control effect:
            enemyPatrolAI1.enemySpeed = 16f;
            enemyPatrolAI2.enemySpeed = 5f;

            togglingPlatformManager1.timeToTogglePlatform = 0.125f;
            togglingPlatformManager2.timeToTogglePlatform = 0.175f;
            togglingPlatformManager3.timeToTogglePlatform = 0.2f;

            Debug.Log("Speed Up"); // for testing
        }
    }
}
