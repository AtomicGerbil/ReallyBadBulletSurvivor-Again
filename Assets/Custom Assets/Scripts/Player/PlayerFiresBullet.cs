using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerFiresBullet : MonoBehaviour
{
    public int MaxBulletCount = 3;
    public float Cooldown = 5; // Cooldown used in conjuction with the variable below.

    private int currentBulletCount = 0;
    private float currentCooldown = 0;

    public Transform firePoint;
    public GameObject bulletsPrefab;

    private void Start()
    {
        currentBulletCount = MaxBulletCount;
        print("Current Bullet Count" + currentBulletCount);
        // Calls to the ObjectPooler that we'll be calling instances from it.
    }
    void Update()
    {
        if (currentBulletCount <= MaxBulletCount) //Keep counting down the cooldown if we're not at max bullets.
        {
            currentCooldown -= Time.deltaTime; //Decrease the cooldown.
            if (currentCooldown < 0) //If the cooldown went below zero, reset the ammo.
                currentBulletCount = MaxBulletCount;
        }

        if (Input.GetKeyUp(KeyCode.D) == true)
        {
            // If player presses 'D', 'FireBullet' activates.
            // This fires a bullet, unsurprisingly.
            FireBullet(); 
        }

    }

    void FireBullet()
    {
        if (currentBulletCount > 0) //If we have bullets left
        {
            currentBulletCount--; //Decrease the count
            Object.Instantiate(bulletsPrefab, firePoint.position, firePoint.rotation);
            currentCooldown = Cooldown; //Reset the cooldown.
        }
    }
}