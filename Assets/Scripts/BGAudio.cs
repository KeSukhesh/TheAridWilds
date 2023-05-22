using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudio : MonoBehaviour
{
    private static BGAudio instance = null; // set instance
    public static BGAudio Instance { get { return instance; } } // all scenes can access this instance

    void Awake()
    {
        if (instance != null && instance != this) { //If instance isnt used (music isn't being played)
            Destroy(this.gameObject); // Destroy gameobject
            return;
        }
        else
            instance = this; // else let instance remain
        DontDestroyOnLoad(transform.root.gameObject); // Prevents the Background Music Audio source from being destroyed during scene chage (it carries over so music doesn't restart)
    }
}
