using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountManager : MonoBehaviour
{
    public int level = 1;
    public static int score = 0;

    #region Singletion
    public static CountManager instance;
    
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
    private void Start()
    {
        
    }

}
