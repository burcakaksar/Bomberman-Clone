using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSoundScript : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] AudioClip sound;
    AudioSource audioSource;

    #region Singletion
    public static IntroSoundScript instance;
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
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            Destroy(this.gameObject);
        }
    }
    public void PlayIntro()
    {
        audioSource.PlayOneShot(sound);
    }
}


