using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WinDoor : MonoBehaviour
{
    Canvas winPanel;


    void Start()
    {
        winPanel = GameObject.FindGameObjectWithTag("WinPanel").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (AllEnemyDestroyed())
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                winPanel.enabled = true;
                Time.timeScale = 0f;
                Debug.Log("Win Panel");
                SoundManagerScript.instance.PlaySound(9);
                collision.gameObject.SetActive(false);
            }
        }
    }
    public bool AllEnemyDestroyed()
    {
        foreach (var item in EnemyManager.instance.EnemyList)
        {
            if (item != null)
            {
                return false;
            }
        }
        return true;
    }
}
