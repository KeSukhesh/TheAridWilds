using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void CompleteLevel() // If level is completed this function is called
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load next scene
        Debug.Log("LEVEL WON!"); // Console testing for collision
    }
}
