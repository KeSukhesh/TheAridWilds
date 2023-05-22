using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSound : MonoBehaviour
{

    AudioSource source; // Refrence to audio source that is playing the sfx


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>(); // set reference upon start
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) // If the music is no longer playing
        {
            Destroy(gameObject); // Destroy the game object -> Destroying this prevents sound gamobjects from piling and taking over memory
        }
    }
}
