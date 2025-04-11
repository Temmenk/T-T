using System;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool GameIsPaused = false; // Static variable to track if the game is paused
    public GameObject pauseMenuUI; // Reference to the pause menu UI GameObject
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Check if the Escape key is pressed
        {
            if (GameIsPaused)
            {
                Resume(); // Call the Resume method if the game is currently paused
            }
            else
            {
                Pause(); // Call the Pause method if the game is not paused
            }
        }
    }
        public void Resume()
        {
            pauseMenuUI.SetActive(false); // Deactivate the pause menu UI
            Time.timeScale = 1f; // Set the time scale to 1 to resume the game
            GameIsPaused = false; // Set the game paused state to false
        }
        void Pause()
        {
            pauseMenuUI.SetActive(true); // Activate the pause menu UI
            Time.timeScale = 0f; // Set the time scale to 0 to pause the game
            GameIsPaused = true; // Set the game paused state to true
        }
        public void LoadMenu()
        {
            Debug.Log("Loading menu..."); // Log a message indicating the loading of the menu
            Time.timeScale = 1f; // Set the time scale to 1 to resume the game
            // Load the main menu scene here (if applicable)
        }
        public void QuitGame()
        {
            Debug.Log("Quitting game..."); // Log a message indicating the quitting of the game
            Application.Quit(); // Quit the application
        }
}
