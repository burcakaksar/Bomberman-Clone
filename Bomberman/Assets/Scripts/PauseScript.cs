using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] Canvas pauseCanvas;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeButton();
                Debug.Log("isPaused true");
            }
            else 
            {
                PauseButton();
                SoundManagerScript.instance.PlaySound(2);
                Debug.Log("isPaused false");
            }
        }
    }

    public void ResumeButton()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
        Movement.canMove = true;
        Debug.Log("Resume");
    }
    public void PauseButton()
    {
        pauseCanvas.enabled = true;
        Time.timeScale = 0f;
        isPaused = true;
        Movement.canMove = false;
        Debug.Log("Pause");

    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
        Movement.canMove = true;
        CountManager.score = 0;
        Debug.Log("Restart");

    }
    public void MenuButton()
    {
        SceneManager.LoadScene(2);
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
        isPaused = false;
        Movement.canMove = true;
        CountManager.instance.level = 1;
    }

}
