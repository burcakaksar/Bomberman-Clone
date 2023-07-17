using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerSpawnPosition;
    
    public int bombCount = 1;
    public bool canBomb = true;

    public int playerLife = 3;
    public float playerMoveSpeed;

    public int enemySpeed;

    public  int explosionPower;


    #region Singletion
    public static LevelManager instance;
    private void Awake()
    {

        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerSpawnPosition = GameObject.FindGameObjectWithTag("PlayerSpawnPos");

    }
    #endregion 
    private void Start()
    {
        explosionPower = 1;
        bombCount = 1;
        enemySpeed = LevelPanelScript.enemySpeed;
        PlayerSpawn();
    }


    public void PlayerSpawn()
    {
        Instantiate(player, playerSpawnPosition.transform.position, Quaternion.identity);
        PlayerSettingsReset();
    }
    public void RespawnPlayer()
    {
        Debug.Log("Respawn");
        Instantiate(player, playerSpawnPosition.transform.position, Quaternion.identity);
        PlayerSettingsReset();
    }
    public void RespawnDelay()
    {
        StartCoroutine("DelayTime");
    }
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(2.2f);
        if(playerLife>=1)
        {
            RespawnPlayer();
        }
    }
    public void PlayerSettingsReset()
    {
        if (GameObject.FindGameObjectWithTag("Bomb") == null)
        {
            bombCount = 1;
        }
        else
        {
            bombCount = 0;
        }
        Movement.canMove = true;
        playerMoveSpeed = 4;
        explosionPower = 1;
        canBomb = true;
    }
}
