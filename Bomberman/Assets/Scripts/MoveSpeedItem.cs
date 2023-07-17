using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.playerMoveSpeed+=1;
            Destroy(gameObject);
            SoundManagerScript.instance.PlaySound(7);
        }
    }

}
