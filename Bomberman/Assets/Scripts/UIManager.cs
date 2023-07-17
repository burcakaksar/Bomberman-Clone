using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Image[] playerHealths;
    [SerializeField] Canvas gameOver;
    public int highScore;
    public float timeLeft;
    public bool timeLeft10SecondsActive = false;

    #region Singletion
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion 
    
    void Start()
    {
        timeLeft = LevelPanelScript.modeTime;
        highScore = PlayerPrefs.GetInt("HighScore");
    }

// Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 10)
        {
            if (!timeLeft10SecondsActive)
            {
                SoundManagerScript.instance.PlaySound(8);
                timeLeft10SecondsActive = true;
                Invoke("ChangeTimeLeft10Seconds", 12f);
            }
        }

        timerText.text = "Time: " + (int)timeLeft;
        levelText.text = "Level: " + CountManager.instance.level;
        scoreText.text = "Score:" + CountManager.score;

       
        if (highScore < CountManager.score)
        {
            PlayerPrefs.SetInt("HighScore", CountManager.score);
        }
    }

    public void PlayerLifeLost()
    {
        LevelManager.instance.playerLife--;
        Destroy(playerHealths[LevelManager.instance.playerLife]);
        timeLeft = LevelPanelScript.modeTime+2;
        Debug.Log("playerLife" + LevelManager.instance.playerLife);
        if (LevelManager.instance.playerLife < 1)
        {
            gameOver.enabled = true;
            InvokeRepeating("PlayGameOverSound",0,9);
        }
    }

    public void PlayGameOverSound()
    {
        SoundManagerScript.instance.PlaySound(12);
    }
    public void ChangeTimeLeft10Seconds()
    {
        timeLeft10SecondsActive = false;
    }
}
