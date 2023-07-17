using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static bool canMove = true;
    public Rigidbody2D rb;
    public Vector2 direction = Vector2.down;
    //SpriteRenderer spriteRenderer;
    [SerializeField] float moveSpeed;
   
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    public AnimationSpriteRenderer spriteRendererUp;
    public AnimationSpriteRenderer spriteRendererDown;
    public AnimationSpriteRenderer spriteRendererLeft;
    public AnimationSpriteRenderer spriteRendererRight;
    public AnimationSpriteRenderer spriteRendererDeath;

    public bool playerWalkSoundActive = true;
    public bool playerStopedSound = true;

    private AnimationSpriteRenderer activeSpriteRenderer;
    [SerializeField] GameObject playerDeath;

    private bool isPlayedDeath = false;
    public float playerDeathTime;
    public bool isPlayerTriggered = false;

    bool isFunctionCalled = false;
    public bool isPlayerDeathByEnemy = false;

    AudioSource audioSource;

    void Start()
    {
        playerDeathTime = UIManager.instance.timeLeft;
        rb = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down, spriteRendererDown);
        Invoke("DeathSequence", playerDeathTime);
        audioSource = GetComponent<AudioSource>();
    }
   
    
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * LevelManager.instance.playerMoveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
    }

    public void Move()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
            PlayerWalkSound();
            //SoundManagerScript.instance.PlaySound(1);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
            PlayerWalkSound();
            //SoundManagerScript.instance.PlaySound(1);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
            PlayerWalkSound();
            //SoundManagerScript.instance.PlaySound(1);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
            PlayerWalkSound();
            //SoundManagerScript.instance.PlaySound(1);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
            audioSource.Stop();
            //SoundManagerScript.instance.PlaySound(1);
        }
    }
    private void SetDirection(Vector2 newDirection, AnimationSpriteRenderer spriteRenderer)
    {
        direction = newDirection;
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            if (!isPlayerTriggered)
            {
                isPlayerTriggered = true;
                canMove = false;
                DeathSequence();
            }
        }

    }
    public void DeathSequence()
    {
        PlayerReset();
        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        Destroy(gameObject);
        SoundManagerScript.instance.PlaySound(5);
        Instantiate(playerDeath,transform.position, Quaternion.identity);
        UnityEngine.Debug.Log("DeathSequence");
        UIManager.instance.PlayerLifeLost();
        OnDeathSequenceEnded();
        Debug.Log("Öldüm");
    }

    private void OnDeathSequenceEnded()
    {
        LevelManager.instance.RespawnDelay();
    }
    public void PlayerReset()
    {
        canMove = false;
        LevelManager.instance.bombCount = 0;
        LevelManager.instance.canBomb = false;
        isPlayedDeath = false;
    }

    public void PlayerDeath()
    {
        StartCoroutine(PlayerDie());
    }

    IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
        canMove = false;
    }
    public void PlayerWalkSound()
    {
        if (playerWalkSoundActive)
        {
            audioSource.Play();
            playerWalkSoundActive = false;
            Invoke("ChangeWalkSound", 1f);
        }
    }
    public void ChangeWalkSound()
    {
        playerWalkSoundActive = true;
    }

}
