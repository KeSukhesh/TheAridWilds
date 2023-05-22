using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5TimeControl : MonoBehaviour
{
    //All gameobjects in level to be affected:
    //3 Initial Platforms
    public DisappearingPlatform togglingPlatformManager;
    public MovingPlatform movingPlatform1;
    public UpDownPlatform upDownPlatform1;
    //Toggling Rock
    public DisappearingPlatform togglingRocks;
    // 3 Toggling PLatforms Puzzle
    public DisappearingPlatform togglingPlatformManager1;
    public DisappearingPlatform togglingPlatformManager2;

    // x ammount of mummy enemies
    public EnemyPatrolAI enemyPatrolAI3;
    public EnemyPatrolAI enemyPatrolAI4;
    public EnemyPatrolAI enemyPatrolAI5;
    public EnemyPatrolAI enemyPatrolAI6;

    // 3 more toggling platforms
    public DisappearingPlatform togglingPlatformManager3;
    public DisappearingPlatform togglingPlatformManager4;
    // 1 mummy
    public EnemyPatrolAI enemyPatrolAI1;
    //1 bird
    public EnemyPatrolAI enemyPatrolAI2;
    //4 toggling platforms
    public DisappearingPlatform togglingPlatformManager5;
    public DisappearingPlatform togglingPlatformManager6;

    // Update is called once per frame
    void Update()
    {
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.H)) // IF user presses H
        {
            // Change values to create slow down effect:
            movingPlatform1.moveSpeed = 0.375f;
            togglingPlatformManager.timeToTogglePlatform = 8f;
            upDownPlatform1.moveSpeed = 1f;
            togglingRocks.timeToTogglePlatform = 0.4f;

            togglingPlatformManager1.timeToTogglePlatform = 8f;
            togglingPlatformManager2.timeToTogglePlatform = 16f;

            togglingPlatformManager3.timeToTogglePlatform = 4f;
            togglingPlatformManager4.timeToTogglePlatform = 8f;

            togglingPlatformManager5.timeToTogglePlatform = 3f;
            togglingPlatformManager6.timeToTogglePlatform = 8f;

            enemyPatrolAI1.enemySpeed = 1f;
            enemyPatrolAI2.enemySpeed = 0.25f;

            enemyPatrolAI3.enemySpeed = 0.25f;
            enemyPatrolAI4.enemySpeed = 0.25f;
            enemyPatrolAI5.enemySpeed = 0.25f;
            enemyPatrolAI6.enemySpeed = 0.25f;


            Debug.Log("Slow down");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.J)) // IF user presses J
        {
            // Change values to create Paused time effect:
            movingPlatform1.moveSpeed = 0f;
            togglingPlatformManager.timeToTogglePlatform = 1000000f;
            upDownPlatform1.moveSpeed = 0f;
            togglingRocks.timeToTogglePlatform = 1000000f;

            togglingPlatformManager1.timeToTogglePlatform = 1000000f;
            togglingPlatformManager2.timeToTogglePlatform = 1000000f;

            togglingPlatformManager3.timeToTogglePlatform = 1000000f;
            togglingPlatformManager4.timeToTogglePlatform = 1000000f;

            togglingPlatformManager5.timeToTogglePlatform = 1000000f;
            togglingPlatformManager6.timeToTogglePlatform = 1000000f;

            enemyPatrolAI1.enemySpeed = 0f;
            enemyPatrolAI2.enemySpeed = 0f;

            enemyPatrolAI3.enemySpeed = 0f;
            enemyPatrolAI4.enemySpeed = 0f;
            enemyPatrolAI5.enemySpeed = 0f;
            enemyPatrolAI6.enemySpeed = 0f;


            Debug.Log("Pause");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.K)) // IF user presses K
        {
            // Change values to let objects resume at normal pace
            movingPlatform1.moveSpeed = 1.5f;
            togglingPlatformManager.timeToTogglePlatform = 2f;
            upDownPlatform1.moveSpeed = 5f;
            togglingRocks.timeToTogglePlatform = 0.1f;

            togglingPlatformManager1.timeToTogglePlatform = 2f;
            togglingPlatformManager2.timeToTogglePlatform = 4f;

            togglingPlatformManager3.timeToTogglePlatform = 1f;
            togglingPlatformManager4.timeToTogglePlatform = 2f;

            togglingPlatformManager5.timeToTogglePlatform = 1.5f;
            togglingPlatformManager6.timeToTogglePlatform = 2f;


            enemyPatrolAI1.enemySpeed = 8f;
            enemyPatrolAI2.enemySpeed = 2f;

            enemyPatrolAI3.enemySpeed = 2f;
            enemyPatrolAI4.enemySpeed = 2f;
            enemyPatrolAI5.enemySpeed = 2f;
            enemyPatrolAI6.enemySpeed = 2f;

            Debug.Log("Play");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.L)) // IF user presses L
        {
            // Change values to let objects fast forward, creating time control effect:
            movingPlatform1.moveSpeed = 6f;
            togglingPlatformManager.timeToTogglePlatform = 0.25f;
            upDownPlatform1.moveSpeed = 20f;
            togglingRocks.timeToTogglePlatform = 0.05f;

            togglingPlatformManager1.timeToTogglePlatform = 0.25f;
            togglingPlatformManager2.timeToTogglePlatform = 0.5f;

            togglingPlatformManager3.timeToTogglePlatform = 0.25f;
            togglingPlatformManager4.timeToTogglePlatform = 0.5f;

            togglingPlatformManager5.timeToTogglePlatform = 0.2f;
            togglingPlatformManager6.timeToTogglePlatform = 0.5f;

            enemyPatrolAI1.enemySpeed = 16f;
            enemyPatrolAI2.enemySpeed = 5f;

            enemyPatrolAI3.enemySpeed = 5f;
            enemyPatrolAI4.enemySpeed = 5f;
            enemyPatrolAI5.enemySpeed = 5f;
            enemyPatrolAI6.enemySpeed = 5f;

            Debug.Log("Speed Up");  // for testing
        }
    }
}
