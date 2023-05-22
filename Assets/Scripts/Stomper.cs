using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{

    public int damageToDeal; // Damage the player's stomper will deal

    private Rigidbody2D theRB2D; // set reference
    public float bounceForce; // force to bounce when collision

    // Start is called before the first frame update
    void Start()
    {
        theRB2D = transform.parent.GetComponent<Rigidbody2D>(); // set refereence
    }

    private void OnTriggerEnter2D(Collider2D other) // collision detection
    {
        if (other.gameObject.tag == "ScorpHurtbox") // if collision with scorpion
        {
            other.gameObject.GetComponent<ScorpionEnemyHP>().TakeDamage(damageToDeal); // pass damage value to that scorpion
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); // let player bounce slight off scorpion's head

            AudioManager.instance.PlaySFX("kill"); // PLay Kill sound effect
        }
        else if (other.gameObject.tag == "MummyHurtbox") // if collision with mummy
        {
            other.gameObject.GetComponent<MummyEnemyHP>().TakeDamage(damageToDeal); // pass damage value to that mummy
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); // let player bounce slight off mummy's head
            AudioManager.instance.PlaySFX("kill"); // PLay Kill sound effect
        }
        if (other.gameObject.tag == "VultureHurtbox") // if collision with vulture
        {
            other.gameObject.GetComponent<VultureEnemyHP>().TakeDamage(damageToDeal); // pass damage value to that vulture
            theRB2D.AddForce(transform.up * bounceForce, ForceMode2D.Impulse); // let player bounce slight off vulture's head
            AudioManager.instance.PlaySFX("kill"); // PLay Kill sound effect
        } 
    }
}
