using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip[] sounds;
    AudioSource audioSource;

    #region Singletion
    public static SoundManagerScript instance;
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
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }
    public void PlaySoundVolume(int index,float volume)
    {
        audioSource.PlayOneShot(sounds[index], volume);
    }
    
}
