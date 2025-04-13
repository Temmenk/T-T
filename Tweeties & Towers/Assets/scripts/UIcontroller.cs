using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    public static UIController Instance; 

    public List<Image> lifeIcons = new List<Image>(); // List to hold life icons

    void Awake()
    {
        Instance = this; // Singleton pattern to ensure only one instance of UIController exists
    }

    public void RemoveLife() // Method to remove a life icon
    {
        if (lifeIcons.Count == 0) return; // If there are no life icons, return
        // Disable the last life icon and remove it from the list

        Image lastLife = lifeIcons[lifeIcons.Count - 1]; // Get the last life icon from the list    
        lastLife.enabled = false; // Disable the last life icon
        lifeIcons.RemoveAt(lifeIcons.Count - 1); // Remove the last life icon from the list
    }
}
