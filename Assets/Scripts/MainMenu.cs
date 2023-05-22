using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int dfltHealth; // deeafualt health val

    private void Start() // Upon scene start
    {
        PlayerPrefs.SetInt("CurrentHealth", dfltHealth); // Store player's current health preferred colour (golden theme pallete)
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If user clicks
            AudioManager.instance.PlaySFX("click"); // Play click sfx
    }

    public void PLayGame() // Player clicks PLay
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load Next scene
    }

    public void QuitGame() // Player wishes to quit
    {
        Application.Quit(); // Close game
    }
}
