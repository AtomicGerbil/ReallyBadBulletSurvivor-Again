using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // Fires right along the X-Axis.
        // With a bit of trickery, I actually rotate the object in 3 dimensional space so that 'right' is inverted when the player faces left.
        // This allows me to fire both directions.
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        isHitByBullet enemy = hitInfo.GetComponent<isHitByBullet>();
        // Gets the name of the object it hits - purely debugging.
        if (enemy != null)
        {
            enemy.TakeDamage(50);
        }
        Destroy(gameObject);
        // Destroys itself when hitting another collider.

    }
}
