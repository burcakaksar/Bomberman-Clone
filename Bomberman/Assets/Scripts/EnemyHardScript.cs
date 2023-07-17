using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardScript : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject playerDeath;

    private float distance;

    void Update()
    { 
        var player = GameObject.FindGameObjectWithTag("Player");
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SoundManagerScript.instance.PlaySound(5);
            Instantiate(playerDeath, collision.transform.position, Quaternion.identity);
            UIManager.instance.PlayerLifeLost();
            LevelManager.instance.RespawnDelay();
        }
    }
}
