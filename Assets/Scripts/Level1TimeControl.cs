using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1TimeControl : MonoBehaviour
{
    // Time control effect for Level 1
    // The only three platforms being affected:
    public DisappearingPlatform togglingPlatformManager1;
    public DisappearingPlatform togglingPlatformManager2;
    public DisappearingPlatform togglingPlatformManager3;

    // Update is called once per frame
    void Update()
    {
        // Change its time scale on key press
        if (Input.GetKeyDown(KeyCode.H)) // IF user presses H
        {
            // Change values to create slow down effect:
            togglingPlatformManager1.timeToTogglePlatform = 8f;
            togglingPlatformManager2.timeToTogglePlatform = 16f;
            togglingPlatformManager3.timeToTogglePlatform = 12f;

            Debug.Log("Slow down"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.J)) // IF user presses J
        {
            // Change values to create Paused time effect:
            togglingPlatformManager1.timeToTogglePlatform = 1000000f;
            togglingPlatformManager2.timeToTogglePlatform = 1000000f;
            togglingPlatformManager3.timeToTogglePlatform = 1000000f;

            Debug.Log("Pause"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.K)) // IF user presses K
        {
            // Change values to let objects resume at normal pace
            togglingPlatformManager1.timeToTogglePlatform = 2f;
            togglingPlatformManager2.timeToTogglePlatform = 4f;
            togglingPlatformManager3.timeToTogglePlatform = 3f;

            Debug.Log("Play"); // for testing
        }
        else if (Input.GetKeyDown(KeyCode.L)) // IF user presses L
        {
            // Change values to let objects fast forward, creating time control effect:
            togglingPlatformManager1.timeToTogglePlatform = 0.125f;
            togglingPlatformManager2.timeToTogglePlatform = 0.175f;
            togglingPlatformManager3.timeToTogglePlatform = 0.2f;

            Debug.Log("Speed Up"); // for testing
        }
    }
}
