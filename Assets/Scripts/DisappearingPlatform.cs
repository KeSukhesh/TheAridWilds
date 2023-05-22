using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{

    public float timeToTogglePlatform = 2; // Time till platform toggles on/off
    public float currentTime = 0; // current time value <- Acts as a timer
    public bool enabled = true; // is platform/object enabled
    
    
    // Start is called before the first frame update
    void Start()
    {
        //enabled = true; <- Object doesn't have to start on
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // Current time is ingame time
        if (currentTime >= timeToTogglePlatform) // If current time equals or exceeds time to toggle
        {
            currentTime = 0; //reset current time value
            TogglePlatform(); // Toggle game object function
        }
    }

    void TogglePlatform() // Says paltform but it can togle any gameobject
    {
        enabled = !enabled; // object no longer enabled
        foreach(Transform child in gameObject.transform) // for every child in parent game object
        {
            child.gameObject.SetActive(enabled); // enable/ deactivate child objeects according to enabled bool
        }
    }

}
