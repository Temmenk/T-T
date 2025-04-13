using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] _monsters;

    [SerializeField] string _nextLevelName;

    [SerializeField] string gameOverSceneName = "GameOver";
    [SerializeField] int birdLimit = 3;
    [SerializeField] float gameOverDelay = 2f;

    int birdsUsed = 0;
    bool isGameOver = false;

    public void BirdLaunched()
    {
        birdsUsed++;
        UIController.Instance.RemoveLife();

        if (birdsUsed >= birdLimit && !MonstersAreAllDead() && !isGameOver)
        {
            isGameOver = true;
            PlayerPrefs.SetString("LastPlayedLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            StartCoroutine(DelayedGameOver());
        }
    }

    IEnumerator DelayedGameOver()
    {
        Debug.Log("Game Over in " + gameOverDelay + " seconds...");
        yield return new WaitForSeconds(gameOverDelay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(gameOverSceneName);
    }

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>(); // Find all active Monster objects in the scene
    }

    void Update()
    {
      if (MonstersAreAllDead())
      {
        GoToNextLevel(); // Call the GoToNextLevel method if all monsters are dead
      }  
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to next level" + _nextLevelName); // Log a message indicating the transition to the next level
        SceneManager.LoadScene(_nextLevelName); // Load the next level using the SceneManager
    }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf) // Check if the monster GameObject is active
            
                return false; // If any monster is still active, return false
        }
                     
            return true; // If all monsters are inactive, return true
                   
    }
}

