using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enemyMove = true;
    public bool enemyMoveX = true;
    public int EnemySpeed = 5;
    Movement movement;
    Rigidbody2D rb;
    [SerializeField] GameObject playerDeath;

    private void Awake()
    {

    }
    void Start()
    {
        InvokeRepeating("EnemyMoveChange", 3, 3);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    private void FixedUpdate()
    {

    }
    void EnemyXMove()
    {
        transform.Translate(-1 * EnemySpeed * Time.deltaTime, 0, 0);
    }
    void EnemyXMovePlus()
    {
        transform.Translate(1 * EnemySpeed * Time.deltaTime, 0, 0);
    }
    void EnemyYMove()
    {
        transform.Translate(0, -1 * EnemySpeed * Time.deltaTime, 0);
    }
    void EnemyYMovePlus()
    {
        transform.Translate(0, 1 * EnemySpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlockWall"))
        {
            enemyMove = !enemyMove;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Instantiate(playerDeath, collision.transform.position, Quaternion.identity);
            UIManager.instance.PlayerLifeLost();
            LevelManager.instance.RespawnDelay();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }


    void EnemyMove()
    {
        if (enemyMoveX)
        {
            if (enemyMove)
            {
                EnemyXMove();
            }
            else
            {
                EnemyXMovePlus();
            }
        }
        else
        {
            if (enemyMove)
            {
                EnemyYMove();
            }
            else
            {
                EnemyYMovePlus();
            }
        }

    }
    public void EnemyMoveChange()
    {
        enemyMoveX = !enemyMoveX;
    }
}
