using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool enemyMove = true;
    public bool enemyMoveX = true;

    public bool isEnemyMoveChanged= false;

    public bool isEnemyMoveChangedBrick = false;


    public bool enemyCanMoveXPositive;
    public bool enemyCanMoveXNegative;
    public bool enemyCanMoveYPositive;
    public bool enemyCanMoveYNegative;

    GameObject enemyMoveXPositiveObject;
    GameObject enemyMoveYPositiveObject;
    GameObject enemyMoveXNegativeObject;
    GameObject enemyMoveYNegativeObject;

    CircleCollider2D circleCollider;

    Movement movement;
    Rigidbody2D rb;
    [SerializeField] GameObject playerDeath;

    private void Awake()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Enemy: " + LevelManager.instance.enemySpeed);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
          EnemyMove();
    }
    void EnemyXMove()
    {
        rb.velocity = Vector3.left * LevelManager.instance.enemySpeed;
    }
    void EnemyXMovePlus()
    {
        rb.velocity = Vector3.right * LevelManager.instance.enemySpeed;
    }
    void EnemyYMove()
    {
        rb.velocity = Vector3.down * LevelManager.instance.enemySpeed;
    }
    void EnemyYMovePlus()
    {
        rb.velocity = Vector3.up * LevelManager.instance.enemySpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Instantiate(playerDeath, collision.transform.position, Quaternion.identity);
            SoundManagerScript.instance.PlaySound(5);
            UIManager.instance.PlayerLifeLost();
            LevelManager.instance.RespawnDelay();
        }
        if (collision.gameObject.CompareTag("BlockWall") )
        {
            Debug.Log("Enemy Bloka çarptý");
            if (!isEnemyMoveChanged)
            {
                enemyMove = !enemyMove;
                isEnemyMoveChanged = true;
                Invoke("EnemyMoveChanged",0.2f);
            }
            
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            if (!isEnemyMoveChangedBrick)
            {
                Debug.Log("Enemy Tuðlaya Çarptu");
                enemyMove = !enemyMove;
                Invoke("EnemyMoveChanged",0.2f);
            }
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            if (!isEnemyMoveChangedBrick)
            {
                Debug.Log("Enemy Bombaya Çarptý");
                enemyMove = !enemyMove;
                Invoke("EnemyMoveChanged", 0.2f);
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bomb"))
    //    {
    //        circleCollider = collision.gameObject.GetComponent<CircleCollider2D>();
    //        circleCollider.isTrigger = false;
    //        Debug.Log("Collider true oldu");
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bomb"))
    //    {
    //        circleCollider = collision.gameObject.GetComponent<CircleCollider2D>();
    //        circleCollider.isTrigger = true;
    //        Debug.Log("Collider false ");
    //    }
    //}
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
        float xPosition = Mathf.Round(transform.position.x);
        float yPosition = Mathf.Round(transform.position.y); ;
        transform.position = new Vector2 (xPosition, yPosition);
        enemyMoveX = !enemyMoveX;
    }
    public void EnemyMoveChanged()
    {
        isEnemyMoveChanged = false;
    }

    public void EnemyMoveChangedBrick()
    {
        isEnemyMoveChangedBrick = false;
    }

}
