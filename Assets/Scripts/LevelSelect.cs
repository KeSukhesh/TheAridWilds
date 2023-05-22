using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AudioManager.instance.PlaySFX("click");
    }

    public void Tutorial() // Player clicks tutorial level
    {
        StartCoroutine(TutorialLevel()); // Call corresponding function
    }
    public void Level1() // Player clicks level 1
    {
        StartCoroutine(LevelOne()); // Call corresponding function
    }
    public void Level2() // Player clicks level 2
    {
        StartCoroutine(LevelTwo()); // Call corresponding function
    }
    public void Level3() // Player clicks level 3
    {
        StartCoroutine(LevelThree()); // Call corresponding function
    }
    public void Level4() // Player clicks level 4
    {
        StartCoroutine(LevelFour()); // Call corresponding function
    }
    public void Level5() // Player clicks level 5
    {
        StartCoroutine(LevelFive()); // Call corresponding function
    }

    IEnumerator TutorialLevel()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("TutorialLevel"); // Load level 1
    }

    IEnumerator LevelOne()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("levelOne"); // Load level 1
    }

    IEnumerator LevelTwo()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("levelTwo"); // Load level 2
    }

    IEnumerator LevelThree()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("levelThree"); // Load level 3
    }

    IEnumerator LevelFour()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("levelFour"); // Load level 41
    }

    IEnumerator LevelFive()  // Function to let click sound effect play before changin scene and causing weird cutoff audio clipping
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //And load the scene
        SceneManager.LoadScene("levelFive"); // Load level 5
    }
}
