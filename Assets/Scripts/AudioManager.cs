using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Script is accessible from other scripts
    void Awake() {  instance = this; } // Set instance

    //Sound Effects
    public AudioClip sfx_kill, sfx_jump, sfx_click, sfx_coin;

    //Sound Object
    public GameObject soundObject;


    public void PlaySFX(string sfxName) // Play SFX function that is called by other scripts
    {
        switch(sfxName) // A switch lets the sfxName that is passed through to be sorted int othe following cases:
        {
            case "kill": // If kill is typed in
                SoundObjectCreation(sfx_kill); // play corresponding sound
                break;
            case "jump": // If jump is typed in
                SoundObjectCreation(sfx_jump); // play corresponding sound
                break;
            case "click": // If click is typed in
                SoundObjectCreation(sfx_click); // play corresponding sound
                break;
            case "coin": // If coin is typed in
                SoundObjectCreation(sfx_coin); // play corresponding sound
                break;
            default:
                break;
        }
    }

    void  SoundObjectCreation(AudioClip clip) // This function tkaes a blank prefab with an audio source attached to it and plays the sfx clip called (this can stack hence the killsfx script)
    {
        //Create SoundsObject gameObject
        GameObject newObject = Instantiate(soundObject, transform); // Create gameObject in hierarchy
        //Assign audioclip to its audiosource
        newObject.GetComponent<AudioSource>().clip = clip; // Get the correct audio clip
        //Play the audio
        newObject.GetComponent<AudioSource>().Play(); // Play the audio clip
    }
}
