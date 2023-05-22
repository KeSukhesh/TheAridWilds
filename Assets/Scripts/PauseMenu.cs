using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; // Allocate pause menu in inspector
    [SerializeField] GameObject helpMenu; //Allocate Help Menu in inspector
      
     public PlayerController playerController; // reference to PLayer Controller Script
 
     void Start()
     {
        // Finds the object the script "IGotBools" is attached to and assigns it to the gameobject called g.
        GameObject g = GameObject.Find("Player");
        //assigns the script component "IGotBools" to the public variable of type "IGotBools" names boolBoy.
        playerController = g.GetComponent<PlayerController> ();
        playerController.ctrlActive = true; // Player should start the level able to move
     }
     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) //If user presses "P" or"ESC"
        {
            if (pauseMenu.activeInHierarchy) // If the Pause menu is open
            {
                Resume(); //Close pause menu
            }
            else
            {
                Pause(); //Open Pause menu
            }

            if (helpMenu.activeInHierarchy) // If Help menu is open
            {
                ResumeFromHelp(); // Close help menu
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) // If user presses "R"
        {
            Restart(); //Restart Level
        }

        if (Input.GetKeyDown(KeyCode.F1)) // If user presses "F1"
        {
            Help(); // Open Help menu
        }
    }

    public void Pause() // If player presses pause button
    {
        pauseMenu.SetActive(true); // open menu
        Time.timeScale = 0f; // pause time going on ingame
        playerController.ctrlActive = false; // DOn't let player move while paused
    }

    public void Help() // if player preesses help button
    {
        helpMenu.SetActive(true); //open menu
        Time.timeScale = 0f; // pause time going on ingame
        playerController.ctrlActive = false; // DOn't let player move while paused
    }

    public void ResumeFromHelp() // PLayer clicks resume button on help screen
    {
        helpMenu.SetActive(false); //close menu
        Time.timeScale = 1f; //Resume ingame time
        playerController.ctrlActive = true; // Let player move again
    }

    public void Resume() // player clicks resume of pause menu
    {
        pauseMenu.SetActive(false); //close pause menu
        Time.timeScale = 1f; // resume time to normal
        playerController.ctrlActive = true; // Let player move again
    }

    public void Home() // PLayer clicks Main Menu button, SceneID = 0, its just assigned in inspector
    {
        Time.timeScale = 1f; // time can play normally so music isn't distorted
        StartCoroutine(GotoMainMenu()); // Start function
    }

    IEnumerator GotoMainMenu() // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("Main Menu"); // Load Main Menu
    }

    public void Restart() // Player clicks restart button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart Level
    }
}
