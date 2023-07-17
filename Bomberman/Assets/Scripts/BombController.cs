using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [Header("Explosion")]
    float explosionDuration = 1f;
    public int explisionRadius = 1;
    Explosion explosion;
    [SerializeField] Explosion explosionPreFab;
    [SerializeField] public LayerMask explosionLayerMask;
    [SerializeField] public LayerMask brcikLayerMask;
    CircleCollider2D circleCollider;

    [SerializeField] GameObject bomb;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
        Invoke("BombDestroy", 3f);
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        SoundManagerScript.instance.PlaySound(0);
        InvokeRepeating("PutBombSound", 0, 2);
    }
    private void Update()
    {
        Debug.Log(CheckEnemy());
    }

    public void BombDestroy()
    {
        Destroy(gameObject);
        LevelManager.instance.bombCount++;
        ExplosionStart();
    }
    public void ExplosionStart()
    {
        Vector2 position = transform.position;
        Explosion explosion = Instantiate(explosionPreFab, position, Quaternion.identity);
        explosion.SetActiveRenderer(explosion.start);
        Destroy(explosion.gameObject, explosionDuration);


        Explode(position, Vector2.up, LevelManager.instance.explosionPower);
        Explode(position, Vector2.down, LevelManager.instance.explosionPower);
        Explode(position, Vector2.left, LevelManager.instance.explosionPower);
        Explode(position, Vector2.right, LevelManager.instance.explosionPower);

    }
    public void Explode(Vector2 position, Vector2 direction, int lenght)
    {
        if (lenght <= 0)
        {
            return;
        }
        position += direction;
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            return;
        }
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, brcikLayerMask))
        {
            Explosion explosion2 = Instantiate(explosionPreFab, position, Quaternion.identity);
            explosion2.SetActiveRenderer(explosion2.end);
            explosion2.SetDirection(direction);
            Destroy(explosion2.gameObject, explosionDuration);
            return;
        }
        Explosion explosion = Instantiate(explosionPreFab, position, Quaternion.identity);
        explosion.SetActiveRenderer(lenght > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        Destroy(explosion.gameObject, explosionDuration);

        Explode(position, direction, lenght - 1);
    }
    bool CheckEnemy()
    {
        return Physics2D.OverlapCircle(transform.position, radius, layerMask);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !CheckEnemy())
        {
            circleCollider.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            circleCollider.isTrigger = false;
        }
        if (collision.gameObject.CompareTag("EnemyNormal"))
        {
            circleCollider.isTrigger = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void PutBombSound()
    {
        SoundManagerScript.instance.PlaySound(0);
    }
}
