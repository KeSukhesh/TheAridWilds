using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public string keepLevelName; // store level name

    Vector2 playerInitPosition; // PLayer's initial position (at start of level)

    void Start()
    {
        keepLevelName = SceneManager.GetActiveScene().name; // store level name

        playerInitPosition = FindObjectOfType<Player>().transform.position; // set reference to players init pos
    }

    public void Restart() // restart level function
    {
        // Restart the scene
        SceneManager.LoadScene(keepLevelName, LoadSceneMode.Single);
        // Reset the player's position,
        // Save player's initial position when game start
        //When repsawning simply reposition the player ot that init position
    }
}
