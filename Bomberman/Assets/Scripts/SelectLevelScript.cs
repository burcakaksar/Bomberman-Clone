using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
    public void Level2()
    {
        PlayerPrefs.SetInt("Level", 2);
    }
    public void Level3()
    {
        PlayerPrefs.SetInt("Level", 3);
    }
}
