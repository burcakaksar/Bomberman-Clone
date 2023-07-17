using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BombInstante : MonoBehaviour
{
    
    [SerializeField] GameObject bomb;
    [SerializeField] Tilemap tilemap;
    CircleCollider2D circleCollider;

    public int bombMaxCount;
    private Transform bombPalace;

    private void Start()
    {
        tilemap = GameObject.FindGameObjectWithTag("GroundTag").GetComponent<Tilemap>();
        
    }
    private void Update()
    {
        Bomb();
    }
    

    public void Bomb()
    {
        if (LevelManager.instance.bombCount  > 0 && LevelManager.instance.canBomb )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(!PauseScript.isPaused)
                {
                    Vector3 worldPos = gameObject.transform.position;
                    Vector3Int cell = tilemap.WorldToCell(worldPos);
                    Vector3 centerPos = tilemap.GetCellCenterWorld(cell);
                    Instantiate(bomb, centerPos, Quaternion.identity);
                    SoundManagerScript.instance.PlaySound(0);
                    LevelManager.instance.bombCount--;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BombPlace"))
        {
            Debug.Log("BombPlace");
            bombPalace = collision.gameObject.GetComponent<Transform>();
            
        }
    }

}
