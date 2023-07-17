using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AnimationSpriteRenderer start;
    public AnimationSpriteRenderer middle;
    public AnimationSpriteRenderer end;

    [SerializeField] GameObject speedItem;
    [SerializeField] GameObject explosionPowerItem;
    [SerializeField] GameObject bombItem;

    [SerializeField] GameObject deathEnemy;
    [SerializeField] GameObject deathEnemyNormal;
    [SerializeField] GameObject deathEnemyHard;
    [SerializeField] GameObject deathEnemyRed;
   
    

    [SerializeField] GameObject destruction;
    public int randomNumber;

    public int randomNumberRange;
    private void Start()
    {
        randomNumberRange = LevelPanelScript.randomRangeNumber;
        randomNumber = UnityEngine.Random.Range(1, randomNumberRange);
        SoundManagerScript.instance.PlaySoundVolume(4, 0.3f);
    }
    public void SetActiveRenderer(AnimationSpriteRenderer renderer)
    {
        start.enabled = renderer == start;
        middle.enabled = renderer == middle;
        end.enabled = renderer == end;
    }
    public void SetDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * 360 / (MathF.PI * 2), Vector3.forward);
    }
    public void DestroyAfter(float seconds)
    {
        Destroy(gameObject, seconds);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
            Instantiate(destruction,collision.gameObject.transform.position, Quaternion.identity);
            BrickDestroy(collision.gameObject);
            CountManager.score += 10;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(deathEnemy,collision.gameObject.transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            
            CountManager.score += 50;
        }
        if (collision.gameObject.CompareTag("EnemyHard"))
        {
            Instantiate(deathEnemyHard, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            CountManager.score += 150;
        }
        if (collision.gameObject.CompareTag("EnemyNormal"))
        {
            Instantiate(deathEnemyNormal, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            CountManager.score += 100;
        }
        if(collision.gameObject.CompareTag("EnemyRed"))
        {
            Instantiate(deathEnemyRed,collision.gameObject.transform.position,Quaternion.identity) ;
            Destroy(collision.gameObject);
            CountManager.score += 75;
        }
        


    }
    public void BrickDestroy(GameObject collision)
    {

        if (randomNumber == 1)
        {
            var obje = Instantiate(speedItem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(obje,5);
        }
        else if (randomNumber == 2)
        {
            var obje = Instantiate(explosionPowerItem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(obje, 5);
        }
        else if (randomNumber == 3)
        {
            var obje = Instantiate(bombItem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(obje, 5);
        }

    }
}
