using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image blackImage;
    public Color color;
    public bool isMusicPlayed = false;
    void Start()
    {
        Debug.Log(blackImage.color.a);
        color = blackImage.color;
        InvokeRepeating("ChangeAlpha", 0.1f, 0.1f);
        Invoke("NextScene", 5f);
        Invoke("PlayMusicSound", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //if (!isMusicPlayed)
        //{
        //    SoundManagerScript.instance.PlaySound(6);
        //    isMusicPlayed = true;
        //}
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ChangeAlpha()
    {
        color.a += 0.02f;
        blackImage.color = color;
    }
    public void PlayMusicSound()
    {
        IntroSoundScript.instance.PlayIntro();
    }
}
