using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    // Update is called once per frame
    void Update()
    {
        FacingPlayer();
    }

    void FacingPlayer()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        // Did some digging + had Brackeys to help.
        // Essentially A* Pathfinding gives positive and negative forces depending on where the player is.
        // We can use these to determine which way the AI is moving and simply have the sprite flip accordingly to how it moves.
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }

        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
    }
}
