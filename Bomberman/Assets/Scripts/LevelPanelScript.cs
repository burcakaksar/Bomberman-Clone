using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPanelScript : MonoBehaviour
{
    public static int modeTime;
    public static int enemySpeed;
    public static float enemyChangePositionTime;
    public static int randomRangeNumber;
    public static int defaultLevel;
    public static int selectedLevel;
    EnemyScript enemyScript;
    private void Start()
    {
    }
    public void EasyMode()
    {
        modeTime = 300;
        enemySpeed = 1;
        randomRangeNumber = 5;
        enemyChangePositionTime = 0.2f;
        selectedLevel = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ selectedLevel);
        CountManager.instance.level = selectedLevel;
        Debug.Log("1 nolue ekrana geçti");
        CountManager.score = 0;
    }
    public void NormalMode()
    {
        modeTime = 200;
        enemySpeed = 2;
        randomRangeNumber = 20;
        enemyChangePositionTime = 0.1f;
        selectedLevel = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + selectedLevel);
        CountManager.instance.level = selectedLevel;
        Debug.Log("1 nolue ekrana geçti");
        CountManager.score = 0;

    }
    public void HardMode()
    {
        modeTime = 100;
        enemySpeed = 3;
        randomRangeNumber = 50;
        enemyChangePositionTime = 0.1f;
        selectedLevel = PlayerPrefs.GetInt("Level");
        CountManager.instance.level = selectedLevel;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + selectedLevel);
        Debug.Log("1 nolue ekrana geçti");
        CountManager.score = 0;
    }
}
