using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelTimeControl : MonoBehaviour
{
    //All gameobjects in level to be affected:
    public MovingPlatform movingPlatform1;
    public FallingPlatform fallingPlatform; // Doeesn't get time controlled 
    public DisappearingPlatform togglingPlatformManager1;
    public UpDownPlatform upDownPlatform1;
    public UpDownPlatform upDownPlatform2;

    // 1 mummy
    public EnemyPatrolAI enemyPatrolAI1;
    //1 bird
    public EnemyPatrolAI enemyPatrolAI2;

    // Update is called once per frame
    void Update()
    {
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.H)) // IF user presses H
        {
            // Change values to create slow down effect:
            movingPlatform1.moveSpeed = 0.75f;
            upDownPlatform1.moveSpeed = 0.25f;
            upDownPlatform2.moveSpeed = 0.25f;

            togglingPlatformManager1.timeToTogglePlatform = 8f;

            enemyPatrolAI1.enemySpeed = 0.25f;
            enemyPatrolAI2.enemySpeed = 0.25f;

            Debug.Log("Slow down");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.J)) // IF user presses J
        {
            // Change values to create Paused time effect:
            movingPlatform1.moveSpeed = 0f;
            upDownPlatform1.moveSpeed = 0f;
            upDownPlatform2.moveSpeed = 0f;

            togglingPlatformManager1.timeToTogglePlatform = 1000000f;

            enemyPatrolAI1.enemySpeed = 0f;
            enemyPatrolAI2.enemySpeed = 0f;
            Debug.Log("Pause");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.K)) // IF user presses K
        {
            // Change values to let objects resume at normal pace
            movingPlatform1.moveSpeed = 3f;
            upDownPlatform1.moveSpeed = 2f;
            upDownPlatform2.moveSpeed = 2f;

            togglingPlatformManager1.timeToTogglePlatform = 2f;

            enemyPatrolAI1.enemySpeed = 2f;
            enemyPatrolAI2.enemySpeed = 2f;
            Debug.Log("Play");  // for testing
        }
        else if (Input.GetKeyDown(KeyCode.L)) // IF user presses L
        {
            // Change values to let objects fast forward, creating time control effect:
            movingPlatform1.moveSpeed = 9f;
            upDownPlatform1.moveSpeed = 6f;
            upDownPlatform2.moveSpeed = 6f;

            togglingPlatformManager1.timeToTogglePlatform = 0.25f;

            enemyPatrolAI1.enemySpeed = 8f;
            enemyPatrolAI2.enemySpeed = 8f;
            Debug.Log("Speed Up");  // for testing
        }
    }
}
