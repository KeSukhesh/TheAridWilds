using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox; //Set reference
    public Text dialogText; //Set reference
    public GameObject openSignText; //Set reference
    public GameObject closeSignText; //Set reference
    public string dialog; //Set reference
    public bool playerInRange; // Bool to confirm if player is in range of sign
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) // IF user clicks space bar and the player is in range of sign
        {
            if(dialogBox.activeInHierarchy) // if the sign is open
            {
                dialogBox.SetActive(false); //close sign
            } else //else the sign has to be closed
            {
                dialogBox.SetActive(true); // open sign
                dialogText.text = dialog; // Update text to be displayed

            }
        }


        if(playerInRange) // If player is in range of sign
        {
            if (dialogBox.activeInHierarchy == false) // If sign is closed
            {
                openSignText.SetActive(true); //let player know they can open sign
                closeSignText.SetActive(false); // DOn't tell player to close sign
            }
            if(dialogBox.activeInHierarchy == true) // if sign is open
            {
                openSignText.SetActive(false); // Don't tell player to open the sign
                closeSignText.SetActive(true); // tell the player they can close the sign
            }
        } else // else if player is not in range
        {
            openSignText.SetActive(false); // keep disabled
            closeSignText.SetActive(false); // keep disabled
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // collision to see if player is in range
    {
        if(other.CompareTag("Player")) // if collision with player
        {
            playerInRange = true; // player is now in range
        }
    }

    private void OnTriggerExit2D(Collider2D other) // If player has left sign collision
    {
        if(other.CompareTag("Player")) // If player has left sign collision
        {
            playerInRange = false; // Player is no longer in range
            dialogBox.SetActive(false); // Close sign as player has walked away
        }
    }

}
