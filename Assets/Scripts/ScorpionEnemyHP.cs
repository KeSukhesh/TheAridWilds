using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionEnemyHP : MonoBehaviour
{
    public int enemyHP; // scorpion enemy HP
    private int currentHP; // CUrrent scorpion hp at all times
    public Animator theAnim; // Reference to animator for scorpion
    public Transform player; // Identify which gameobject the player is
    public float attackDistance = 1f; // Distance scorpion can swing sword from
    private bool isDead; // Is the scorpion dead

    private Collider2D parentCol; // Colider for scorpion gameobject
    private Collider2D hurtboxCol; // Colider for scorpion gameobject

    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyHP; // Start with current hp = max enemy hp

        theAnim = transform.parent.GetComponent<Animator>();  // set reference to animator

        parentCol = transform.parent.GetComponent<Collider2D>();  // set refernce to primary collider
        hurtboxCol = GetComponent<Collider2D>();  // set reference to secondary collider
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0) // If scorpion health is less than or equal to 0
        {
            isDead = true;  // the scorpion is dead
            theAnim.SetBool("Dead", isDead); // scorpion death animation plays if scorpion died
            parentCol.enabled = false; //disable collider to avoid further interaction
            hurtboxCol.enabled = false;  //disable collider to avoid furhter interaction
            StartCoroutine("KillSwitch"); // Start Killswitch function
        }

        ScorpionAttackAnimation(); // scorpion can try to sting whenever condition is met.
    }

    public void TakeDamage(int damage) // Function to damage scorpion
    {
        currentHP -= damage; // Player damage is passed through to scorpion HP (scorpion gets hurt)
    }

    void ScorpionAttackAnimation()
    {
        if (Vector2.Distance(transform.position, player.position) < attackDistance) // Player is in close range to scorpion
        {
            theAnim.SetBool("ScorpionAttack", true); // Let scorpion try to sting player
        }
        else if (Vector2.Distance(transform.position, player.position) > attackDistance)
        {
            theAnim.SetBool("ScorpionAttack", false); // Don't sting nothing
        }
    }

    IEnumerator KillSwitch() // Function to destory scorpion when dead
    {
        yield return new WaitForSeconds(2f); // Wait 2 seconds
        Destroy(transform.parent.gameObject); // Destroy parent scorpion game object
    }
}
