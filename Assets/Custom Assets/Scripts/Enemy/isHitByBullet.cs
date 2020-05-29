using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitByBullet : MonoBehaviour
{
    public int health = 100; // Health of enemy.
    public GameObject pathingEntity; // Variable which refers to a GameObject of whatever I attach to this.
    public CanvasScript e_DecrementCounter; // Variable which refers to 'CanvasScript' class.
    // We call this for a specific method, but tag it with 'e_' in reference to 'enemy'.
    public void TakeDamage(int damage) 
    // The scripts of the projectile call this with a parameter passed into it.
    // Effectively we've made a health system for this enemy.
    {
        health -= damage; 
        // Take away health by damage.

        if (health <= 0)
        // If health drops to 0...
        {
            Death();
            // Initiate the death method.
        }
    }

    void Death()
    {
        e_DecrementCounter.DecrementCounter(); // Call 'DecrementCounter' in CanvasScript.
        Destroy(pathingEntity); // Destroy GameObject tied to variable 'PathingEntity'.
        // This is just clean-up.
        Destroy(gameObject); // Destroy itself.
    }
}
