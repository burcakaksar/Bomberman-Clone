using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelManager.instance.bombCount = 1;
        Time.timeScale = 1f;
        PauseScript.isPaused = false;
        Movement.canMove = true;
        CountManager.score = 0;
        CountManager.instance.level = SceneManager.GetActiveScene().buildIndex - 2;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(2);
        LevelManager.instance.bombCount = 1;
        CountManager.instance.level = 0;
        Time.timeScale = 1f;
    }
}
