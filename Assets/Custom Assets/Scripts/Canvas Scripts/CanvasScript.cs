using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int enemiesToKill = 20; // Base starting.
    string currentCount; // Used later for seeing the 'current count'.
    int newCount; // Used later for changing the count.
    public Text enemyCounter; // We'll attach EnemiesKillCount to this.
    public int indexOfLevel; // Used for level changing later.
    // Setting it a public int means I can change this as I wish.

    

    void Start()
    {
        enemyCounter.text = enemiesToKill.ToString(); // Parse enemiesToKill as a string into enemyCounter.text (UI stuff).
        // Gotta have a kill count to start off with, after all.
    }

    public void DecrementCounter()
    {
        currentCount = enemyCounter.text; // currentCount variable is equal to the contents in enemyCounter.text
        newCount = int.Parse(currentCount); // We check if we can parse the currentCount as an integer. If it can, newCount will hold the integer parsed.
        newCount--; // We decrement new count.
        enemyCounter.text = newCount.ToString(); // Convert newCount to string and pass it into enemyCounter.text
        // This probably isn't the most elegant solution, but it's the one I could mangle together by myself.
        // Given lockdown, im simply way too tired to make elegent solutions.

        if (newCount == 0)
        {
            levelSuccess();
        } else
        {
            //do nothing
        }
    }

    // Update is called once per frame
    void levelSuccess()
    {
        SceneManager.LoadScene(indexOfLevel);
        // Loads scene index of whatever 'indexOfLevel' is set to.
    }
}
