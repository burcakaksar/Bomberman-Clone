using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelScript : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        CountManager.instance.level++;
        Time.timeScale = 1f;
        Debug.Log("Win");

    }
    public void MenuButton()
    {
        SceneManager.LoadScene(2);
        CountManager.instance.level = 1;
        Time.timeScale = 1f;
        Debug.Log("Win Menu");
    }
}
