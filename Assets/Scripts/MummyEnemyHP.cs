using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyEnemyHP : MonoBehaviour
{
    public int enemyHP = 1; // Mummy enemy HP
    private int currentHP; // CUrrent mummy hp at all times
    public Animator theAnim; // Reference to animator for mummy
    public Transform player; // Identify which gameobject the player is
    public float mummyAttackDistance = 1f; // Distance mummy can swing sword from
    public bool mummyIsDead; // Is the mummy dead

    private Collider2D parentCol; // Colider for mummy gameobject
    private Collider2D hurtboxCol; // Collider for mummy gameobject

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
        if (currentHP <= 0) // If mummy health is less than or equal to 0
        {
            mummyIsDead = true; // the mummy is dead
            theAnim.SetBool("Dead", mummyIsDead); // Mummy death animation plays if mummy died
            parentCol.enabled = false; //disable collider to avoid further interaction
            hurtboxCol.enabled = false; //disable collider to avoid furhter interaction
            StartCoroutine("KillSwitch"); // Start Killswitch function
        }

        MummyAttackAnimation(); // Mummy can swing whenever condition is met.
    }

    public void TakeDamage(int damage) // Function to damage mummy
    {
        currentHP -= damage; // Player damage is passed through to mummy HP (mummy gets hurt)
    }

    void MummyAttackAnimation()
    {
        if (Vector2.Distance(transform.position, player.position) < mummyAttackDistance) // Player is in close range to mummy
        {
            theAnim.SetBool("MummyAttack", true); // Let mummy swing at player
        }
        else if (Vector2.Distance(transform.position, player.position) > mummyAttackDistance) // Player is not in close range to mummy
        {
            theAnim.SetBool("MummyAttack", false); // Don't swing at nothing
        }
    }

    IEnumerator KillSwitch() // Function to destory mummy when dead
    {
        yield return new WaitForSeconds(2f); // Wait 2 seconds
        Destroy(transform.parent.gameObject); // Destroy parent mummy game object
    }
}
