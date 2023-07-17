using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyChangePosition : MonoBehaviour
{
    int RandomNumber;
    public bool enemyCanMoveXPositive = true;
    public bool enemyCanMoveXNegative = true;
    public bool enemyCanMoveYPositive = true;
    public bool enemyCanMoveYNegative = true;
    EnemyScript enemyScript;
    [SerializeField] Tilemap tilemap;

    void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("GroundTag").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomNumber = Random.Range(1, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyRed") || collision.gameObject.CompareTag("EnemyNormal"))
        {
            enemyScript = collision.gameObject.GetComponentInParent<EnemyScript>();
            if (RandomNumber == 1 )
            {
                Vector3 worldPos = gameObject.transform.position;
                Vector3Int cell = tilemap.WorldToCell(worldPos);
                Vector3 centerPos = tilemap.GetCellCenterWorld(cell);
                Debug.Log("Enemy Tetiklendi");
                collision.transform.position = centerPos;
                EnemyChangePositionByTime();
            }
        }
    }
    public void EnemyChangePositionByTime()
    {
        enemyScript.enemyMoveX = !enemyScript.enemyMoveX;
    }
}
