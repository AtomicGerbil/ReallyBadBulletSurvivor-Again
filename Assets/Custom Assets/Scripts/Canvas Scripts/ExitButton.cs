using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitButton : MonoBehaviour, IPointerClickHandler // Inherit IPointerClickHandler to handle mouse clicking.
{
    public Button retryButton; // Do this to ensure IPointerClickHandler knows what it should be looking out for.
    public void OnPointerClick(PointerEventData data)
    // When pointer is clicked, parses data to IPointerClickHandler and executes the following.
    {
        Application.Quit(); // Exits the game.
    }
}
