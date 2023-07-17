using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI highScoreText;

    private void Update()
    {
        var highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Highscore: " + highScore;
    }
    public void PlayButton()
    {


    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Oyundan çýkýþ yapýldý.");
    }

    public void SliderArrange(float value)
    {
        //AudioListener.volume = value;
        Debug.Log(slider.value);
    }
    
  

}
