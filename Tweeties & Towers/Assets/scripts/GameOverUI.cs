using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Retry()
    {
        string lastPlayedLevel = PlayerPrefs.GetString("LastPlayedLevel", "Level1"); // fallback just in case
        SceneManager.LoadScene(lastPlayedLevel);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Title"); // replace with your menu scene name
    }
}
