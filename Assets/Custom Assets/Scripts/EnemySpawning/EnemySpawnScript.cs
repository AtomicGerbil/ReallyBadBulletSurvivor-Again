using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    int RandSpawnTimer; // Integer for random spawning times, used later.
    public int e_SpawnLimit = 10; // Spawn limit for enemies.
    objectPooler ObjectPooler; // We have objectpooler here since we are calling from an object pool.

    private void Start()
    {
        ObjectPooler = objectPooler.Instance; // Set ObjectPooler to the instance of objectPooler.
        RandSpawnTimer = RandomChange(); // We start RandSpawnTimer on a random integer range.
    }
    // Update is called once per frame
    void LateUpdate() // Do this last, due to low priority; all other Update functions are more important.
    {
        if (e_SpawnLimit != 0)
        {
            if (RandSpawnTimer <= 0) // If RandSpawnTimer is equal or less than 0...
            {
                e_SpawnLimit--;
                spawningTime(RandSpawnTimer);
                // ... initiate function 'spawningTime' with RandSpawnTimer to throw into the parameter.
            } else
            {
                // If RandSpawnTimer isn't equal or less than 0, we take 1 away from it.
                RandSpawnTimer -= 1;
            }
        } else
        {
            //do nothing.
        }
    }

    int RandomChange()
    {
        RandSpawnTimer = Random.Range(100, 500);
        // RandSpawnTimer is given a random integer range of 100 to 500.
        // In 100 updates, an enemy will spawn. In 500, an enemy will spawn.
        // This works 
        return RandSpawnTimer;
        // We return it so the data of RandSpawnTimer is updated.
    }

    void spawningTime(int timer)
    {
        switch (timer) // Uses 'timer' as the parameter to parse.
        {
            case 0:
                // This one is a really weird line since it doesn't make much sense to most people.
                // In short: the switch is comparing timer to the cases: in this case, if timer is 0, it will execute the code within that case.

                ObjectPooler.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
                // Spawns instance of 'enemy' in the game from this spawn point.
                RandomChange();
                // Change RandSpawnTimer with this method.
                break;

            default:
                Debug.LogWarning("If the default initiated here, something may or may not have gone horribly wrong.");
                // No seriously, I wouldn't know what you would have done to get here.
                // If you did, you defied the laws of possibility and the universe is probably gone.
                // And it would probably be way out of my league of fixing, so thanks.
                break;
        }
    }
}