using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isTouchingEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D p_HitInfo)
    {

        // Gets the name of the object it hits - purely debugging.
        if (p_HitInfo.gameObject.tag.Equals("Enemy"))
        {
            SceneManager.LoadScene(1);
            // Loads a scene.
        }
    }
}