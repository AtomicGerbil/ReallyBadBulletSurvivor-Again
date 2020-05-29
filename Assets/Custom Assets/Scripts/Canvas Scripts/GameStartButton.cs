using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStartButton : MonoBehaviour, IPointerClickHandler
{
    public int indexOfLevel; // Lets me set this variable as I wish in the inspector.
    // Means that I can repurpose this button in many areas.
    public void OnPointerClick (PointerEventData data)
    // Checks if the item attached to this is clicked on.
    {
        SceneManager.LoadScene(indexOfLevel);
        // Loads the scene with whatever the corresponding index number is set on this var.
    }
}