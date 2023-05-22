using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // set instance
    public Text text; // reference to text
    int score; // reference to score
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) // if instance isn't set
        {
            instance = this; // this is instance
        }
        
    }

    public void ChangeScore(int coinValue) // function to change text of coins
    {
        score += coinValue; // add value that gets passed in to score
        text.text = "x" + score.ToString(); // display score in HUD
    }
}
