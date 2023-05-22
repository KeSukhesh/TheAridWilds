using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureEnemyHP : MonoBehaviour
{
    public int enemyHP; // vulture enemy HP
    private int currentHP; // CUrrent vulture hp at all times
    public Animator theAnim; // Reference to animator for vulture
    public Transform player; // Identify which gameobject the player is
    public bool vultureIsDead; // Is the vulture dead

    private Collider2D parentCol; // Colider for vulture gameobject
    private Collider2D hurtboxCol; // Collider for vulture gameobject

    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyHP; // Start with current hp = max enemy hp

        theAnim = transform.parent.GetComponent<Animator>(); // set reference to animator

        parentCol = transform.parent.GetComponent<Collider2D>(); // set refernce to primary collider
        hurtboxCol = GetComponent<Collider2D>(); // set reference to secondary collider
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) // If vulture health is less than or equal to 0
        {
            vultureIsDead = true; // the vulture is dead
            theAnim.SetBool("Dead", vultureIsDead); // vulture death animation plays if vulture died
            parentCol.enabled = false; //disable collider to avoid further interaction
            hurtboxCol.enabled = false; //disable collider to avoid further interaction
            StartCoroutine("KillSwitch"); // Start Killswitch function
        }
    }

    public void TakeDamage(int damage) // Function to damage vulture
    {
        currentHP -= damage; // Player damage is passed through to vulture HP (vulture gets hurt)
    }

    IEnumerator KillSwitch() // Function to destory vulture when dead
    {
        yield return new WaitForSeconds(1f); // Wait 1 second
        Destroy(transform.parent.gameObject); // Destroy parent vulture game object
    }
}
