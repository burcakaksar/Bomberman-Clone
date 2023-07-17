using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItemScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.bombCount++;
            Destroy(gameObject);
            SoundManagerScript.instance.PlaySound(7);
        }
    }
}
